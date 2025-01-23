using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera camera;
    [SerializeField] private bool hasTorsoLayer;
    
    private AlienInputController _inputs;
    private Animator _animator;
    
    private int _torsoLayerIndex;
    private float _torsoLayerWeight = 0;
    private float _layerVelocity;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        _inputs = GetComponent<AlienInputController>();
        _animator = GetComponentInChildren<Animator>();
        
        _torsoLayerIndex = _animator.GetLayerIndex("Torso");
    }

    // Update is called once per frame
    void Update()
    {
        camera.Priority = _inputs.IsAiming ? 100 : 0;
        //camera.enabled = _inputs.IsAiming;
        
        if(hasTorsoLayer)
        {
            _torsoLayerWeight = Mathf.SmoothDamp(_torsoLayerWeight, _inputs.IsAiming ? 1f : 0f, ref _layerVelocity, 0.15f);
            _animator.SetLayerWeight(_torsoLayerIndex, _torsoLayerWeight);
        }
        
    }
}
