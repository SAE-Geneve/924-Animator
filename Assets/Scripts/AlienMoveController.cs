using UnityEngine;

public class AlienMoveController : MonoBehaviour
{

    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _runSpeed = 8f;

    [SerializeField] private float _turnSpeed = 100f;
    [SerializeField] private float _fastTurnSpeed = 200f;

    [SerializeField] private bool _isRootMotionned = false;
    [SerializeField] private Transform _rootCharacter;
    
    private AlienInputController _inputs;
    private CharacterController _controller;
    private Animator _animator;

    private int _torsoLayerIndex;
    private float _torsoLayerWeight = 0;
    private float _dampVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputs = GetComponent<AlienInputController>();
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        
        _torsoLayerIndex = _animator.GetLayerIndex("Torso");

    }

    // Update is called once per frame
    void Update()
    {

        _torsoLayerWeight = Mathf.SmoothDamp(_torsoLayerWeight, _inputs.IsAiming ? 1f : 0f, ref _dampVelocity, 0.15f);
        
        _animator.SetLayerWeight(_torsoLayerIndex, _torsoLayerWeight);
        
        if (_isRootMotionned)
        {
            float turnSpeed = _inputs.IsRunning ? _fastTurnSpeed : _turnSpeed;
            _rootCharacter.Rotate(Vector3.up, _inputs.Move.x * turnSpeed * Time.deltaTime);
            
            _animator.SetFloat("Speed", _inputs.Move.y);
        }
        else
        {
            float turnSpeed = _inputs.IsRunning ? _fastTurnSpeed : _turnSpeed;
            transform.Rotate(Vector3.up, _inputs.Move.x * turnSpeed * Time.deltaTime);

            float horizontalSpeed = _inputs.IsRunning ? _runSpeed : _walkSpeed;
            _controller.SimpleMove(transform.forward * (_inputs.Move.y * horizontalSpeed));

            _animator.SetFloat("Speed", _controller.velocity.magnitude);
        }

    }
}
