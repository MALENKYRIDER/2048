using UnityEngine;

public class BoardRenderer : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private GameObject _tilePrefab;
    [SerializeField] private Transform _tileBox;

    private void RebuildBoard()
    {
        for (int i = 0; i < _tileBox.childCount; i++)
        {
            var child = _tileBox.GetChild(i);
            Destroy(child.gameObject);
        }
    }

    private void RedrawBoard()
    {
        for (int row = 0; row < Board.Size; row++)
        {
            for (int column = 0; column < Board.Size; column++)
            {
                int correctTile = _gridManager.Board.GetCells(row, column);

                if (correctTile != 0)
                {
                    var newTile = Instantiate(_tilePrefab, _tileBox);
                    newTile.GetComponent<RectTransform>().anchoredPosition = _gridManager.GetCellCenter(row, column);
                    newTile.GetComponent<TileVisual>().SetupTile(correctTile);
                }
            }
        }
    }

    public void Rebuild()
    {
        RebuildBoard();
        RedrawBoard();
    }
}