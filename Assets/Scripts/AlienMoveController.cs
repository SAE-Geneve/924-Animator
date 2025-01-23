using System;
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

    private float _angleVelocity;
    private Camera _camera;
    private bool _firstAim;

    private void Awake()
    {
        _camera = Camera.main;
    }

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

        if (!_inputs.IsAiming)
        {
            // Not aiming : Rotation
            ReplaceCharacter(_camera.transform);

            if (_inputs.Move.magnitude >= Mathf.Epsilon)
            {

                float horizontalSpeed = _inputs.IsRunning ? _runSpeed : _walkSpeed;
                _animator.SetFloat("Speed", _inputs.Move.magnitude * horizontalSpeed);
                _firstAim = true;
            }
            else
            {
                _animator.SetFloat("Strafe", 0f);
                _animator.SetFloat("Speed", 0f);
            }
        }
        else
        {
            _animator.SetFloat("Strafe", _inputs.Move.x);
            _animator.SetFloat("Speed", _inputs.Move.y * _walkSpeed);
        }


    }
    public void ReplaceCharacter(Transform cameraTransform)
    {

        Debug.Log("Replacing character");

        float targetAngle = cameraTransform.rotation.eulerAngles.y;
        targetAngle += Mathf.Atan2(_inputs.Move.x, _inputs.Move.y) * Mathf.Rad2Deg;

        float actualAngle = Mathf.SmoothDampAngle(_rootCharacter.eulerAngles.y, targetAngle, ref _angleVelocity, 0.25f);

        _rootCharacter.rotation = Quaternion.Euler(0, actualAngle, 0);
    }
}
