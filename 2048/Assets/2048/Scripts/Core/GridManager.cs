using UnityEngine;

public class GridManager : MonoBehaviour
{
    public Board Board { get; private set; }

    [SerializeField] private float _cellSize = 219f;
    [SerializeField] private float _cellSpace = 8f;

    private void Awake()
    {
        Board = new Board();
    }

    public Vector2 GetCellCenter(int row, int column)
    {
        float distanceBetweenTwoCellCenter = _cellSize + _cellSpace;
        float boardSize = Board.Size * _cellSize + (Board.Size -1) * _cellSpace;
        float halfOfBoardSize = boardSize / 2f;

        float x = column * distanceBetweenTwoCellCenter + _cellSize / 2f - halfOfBoardSize;
        float y = halfOfBoardSize - (row * distanceBetweenTwoCellCenter + _cellSize / 2f);
        
        return new Vector2(x, y);
    }
}
