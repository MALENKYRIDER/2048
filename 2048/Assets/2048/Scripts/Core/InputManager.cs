using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private void Update()
    {
        Vector2Int side = Vector2Int.zero;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            side = new Vector2Int(-1, 0);
            Debug.Log(side);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            side = new Vector2Int(1, 0);
            Debug.Log(side);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            side = new Vector2Int(0, -1);
            Debug.Log(side);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            side = new Vector2Int(0, 1);
            Debug.Log(side);
        }
    }
}