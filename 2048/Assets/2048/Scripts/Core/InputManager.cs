using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private MoveManager _moveManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            _moveManager.UpMove();

        if (Input.GetKeyDown(KeyCode.DownArrow))
            _moveManager.DownMove();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            _moveManager.LeftMove();

        if (Input.GetKeyDown(KeyCode.RightArrow))
            _moveManager.RightMove();
    }
}