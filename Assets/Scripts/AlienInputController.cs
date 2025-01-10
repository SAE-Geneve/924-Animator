using UnityEngine;
using UnityEngine.InputSystem;

public class AlienInputController : MonoBehaviour
{
    
    private Vector2 _move;
    private bool _isRunning;

    public Vector2 Move => _move;
    public bool IsRunning => _isRunning;

    public void OnMove(InputAction.CallbackContext context) => _move = context.ReadValue<Vector2>();
    public void OnRun(InputAction.CallbackContext context) => _isRunning = context.ReadValueAsButton();
    
}
