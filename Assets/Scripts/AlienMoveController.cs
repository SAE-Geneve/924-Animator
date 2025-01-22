using UnityEngine;

public class AlienMoveController : MonoBehaviour
{

    [SerializeField] private float _walkSpeed = 2f;
    [SerializeField] private float _runSpeed = 8f;

    [SerializeField] private float _turnSpeed = 100f;
    [SerializeField] private float _fastTurnSpeed = 200f;

    [SerializeField] private bool _isRootMotionned = false;
    [SerializeField] private Transform  _rootCharacter;
    
    private AlienInputController _inputs;
    private CharacterController _controller;
    private Animator _animator;

    private float _angleVelocity;

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

      if (_isRootMotionned)
        {
            if (_inputs.Move.magnitude >= Mathf.Epsilon)
            {
                float targetAngle = Camera.main.transform.rotation.eulerAngles.y;
                targetAngle += Mathf.Atan2(_inputs.Move.x, _inputs.Move.y) * Mathf.Rad2Deg;
            
                float actualAngle = Mathf.SmoothDampAngle(_rootCharacter.eulerAngles.y, targetAngle, ref _angleVelocity, 0.25f);
                
                _rootCharacter.rotation = Quaternion.Euler(0, actualAngle, 0);
                
            }
            
            _animator.SetFloat("Speed", _inputs.Move.magnitude);
            
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
