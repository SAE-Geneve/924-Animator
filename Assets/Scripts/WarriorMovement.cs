using UnityEngine;
using UnityEngine.Serialization;

public class WarriorMovement : MonoBehaviour
{
    
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float turnSpeed = 180f;
    [SerializeField] private float fastTurnSpeed = 250f;
    
    InputController _inputs;
    CharacterController _character;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
      _inputs = GetComponent<InputController>();  
      _character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        float actualSpeed = _inputs.IsRunning ? runSpeed : walkSpeed;
        float actualTurnSpeed = _inputs.IsRunning ? fastTurnSpeed : turnSpeed;
        
        transform.Rotate(Vector3.up, _inputs.Move.x * actualTurnSpeed * Time.deltaTime);
        _character.SimpleMove(transform.forward * (_inputs.Move.y * actualSpeed));

    }
}
