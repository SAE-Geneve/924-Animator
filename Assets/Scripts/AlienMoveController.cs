using UnityEngine;

public class AlienMoveController : MonoBehaviour
{
    
    [SerializeField] public float _walkSpeed = 2f;
    [SerializeField] public float _runSpeed = 8f;
    
    private AlienInputController _inputs;
    private CharacterController _controller;
    private Animator _animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputs = GetComponent<AlienInputController>();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = _inputs.IsRunning ? _runSpeed : _walkSpeed;
        
        _controller.SimpleMove(transform.forward * (_inputs.Move.y * speed));
        
        _animator.SetFloat("Speed", _controller.velocity.magnitude);
        
    }
}
