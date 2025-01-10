using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private Vector2 _move = Vector2.zero;
    bool _isJumping = false;
    bool _isRunning = false;
    bool _isAimimg  = false;
    bool _isShooting = false;
    
    public Vector2 Move => _move;
    public bool IsAimimg => _isAimimg;
    public bool IsRunning => _isRunning;
    public bool IsJumping => _isJumping;
    public bool IsShooting => _isShooting;

    public void OnMove(InputAction.CallbackContext context) => _move = context.ReadValue<Vector2>();
    public void OnJump(InputAction.CallbackContext context) => _isJumping = context.ReadValueAsButton();
    public void OnRun(InputAction.CallbackContext context) => _isRunning = context.ReadValueAsButton();
    public void OnAim(InputAction.CallbackContext context) => _isAimimg = context.ReadValueAsButton();
    public void OnShoot(InputAction.CallbackContext context) => _isShooting = context.ReadValueAsButton();
    
}
