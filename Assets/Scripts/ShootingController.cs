using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera aimCamera;
    [SerializeField] private GameObject aimingPanel;
    [SerializeField] private GameObject spotter;
    [SerializeField] private GameObject targetName;
    
    [SerializeField] private LayerMask aimLayer;
    
    private AlienInputController _inputs;
    private Camera _mainCamera;
    private Transform _startSpotter;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        _inputs = GetComponent<AlienInputController>();
        _mainCamera = Camera.main;
        _startSpotter = spotter.transform;
    }

    // Update is called once per frame
    void Update()
    {
        aimCamera.Priority = _inputs.IsAiming ? 100 : 0;
        aimingPanel.SetActive(_inputs.IsAiming ? true : false);
        
        if(_inputs.IsAiming)
        {
            Ray ray = _mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, _mainCamera.farClipPlane));
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

            if (Physics.Raycast(ray, out RaycastHit hit, _mainCamera.farClipPlane, aimLayer))
            {
                spotter.SetActive(true);
                spotter.transform.position = hit.point;

                if (hit.collider.CompareTag("Targets"))
                {
                    targetName.SetActive(true);
                    targetName.GetComponent<TextMeshProUGUI>().text = hit.collider.name;
                }
                else
                {
                    targetName.SetActive(false);
                }

            }
            
        }
        else
        {
            spotter.transform.SetPositionAndRotation(_startSpotter.position, _startSpotter.rotation);
            spotter.SetActive(false);
        }
        
    }
}
