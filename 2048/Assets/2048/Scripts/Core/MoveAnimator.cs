using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAnimator : MonoBehaviour
{
    [SerializeField] private GridManager _gridManager;
    [SerializeField] private Transform _tileBox;

    public GameObject SearchingCells(Vector2Int position)
    {
        Vector2 pos = _gridManager.GetCellCenter(position.x, position.y);
        
        for (int i = 0; i < _tileBox.childCount; i++)
        {
            var child = _tileBox.GetChild(i);
            if (child.GetComponent<RectTransform>().anchoredPosition == pos)
            {
                return child.gameObject;
            }
        }
        
        return null;
    }

    public IEnumerator MoveAnim(List<(Vector2Int from, Vector2Int to, bool isMerged)> instructions)
    {
        List<(RectTransform tile, Vector2 start, Vector2 end)> pos = new List<(RectTransform tile, Vector2 start, Vector2 end)>();

        for (int i = 0; i < instructions.Count; i++)
        {
            RectTransform tile = SearchingCells(instructions[i].from).GetComponent<RectTransform>();
            Vector2 start = _gridManager.GetCellCenter(instructions[i].from.x, instructions[i].from.y);
            Vector2 end = _gridManager.GetCellCenter(instructions[i].to.x, instructions[i].to.y);
            pos.Add((tile, start, end));
        }
        
        float duration = 0.1f;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {
            var t = elapsed / duration;

            for (int i = 0; i < pos.Count; i++)
            {
                pos[i].tile.anchoredPosition = Vector2.Lerp(pos[i].start, pos[i].end, t);
            }
            
            elapsed += Time.deltaTime;
            yield return null;
        }

        foreach (var position in pos)
        {
            position.tile.anchoredPosition = position.end;
        }

    }
}
