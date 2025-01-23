using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSelector : MonoBehaviour
{
    [SerializeField] private Transform mousePointer;
    
    private Vector2 _mousePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Mouse Position: " + _mousePosition);

        Ray ray = Camera.main.ScreenPointToRay(_mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            mousePointer.position = hit.point;
        }
        
    }

    public void OnMouseCursorPosition(InputAction.CallbackContext ctx)
    {
        _mousePosition = ctx.ReadValue<Vector2>();
    }
}
