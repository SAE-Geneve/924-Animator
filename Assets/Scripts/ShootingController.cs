using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

public class ShootingController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera aimCamera;
    [SerializeField] private CinemachineCamera followCamera;
    [SerializeField] private GameObject aimingPanel;
    [SerializeField] private GameObject spotter;
    [SerializeField] private GameObject targetName;
    [SerializeField] private GameObject playerRoot;
    [SerializeField] private LayerMask aimLayer;

    private AlienInputController _inputs;
    private Camera _mainCamera;
    private Vector3 _startSpotterPosition;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _inputs = GetComponent<AlienInputController>();
        _mainCamera = Camera.main;
        _startSpotterPosition = spotter.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        aimCamera.Priority = _inputs.IsAiming ? 100 : 0;
        followCamera.Priority = _inputs.IsAiming ? 0 : 100;

        if (!_inputs.IsAiming)
        {
            if (aimCamera.TryGetComponent(out CinemachinePanTilt panTilt))
            {
                 panTilt.PanAxis.Value = 0;
                 panTilt.TiltAxis.Value = 0;
            }
            else
            {
                Debug.LogError("Aiming is missing CinemachinePanTilt");
            }
        }

        Ray ray = _mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, _mainCamera.farClipPlane));
        Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit, _mainCamera.farClipPlane, aimLayer))
        {
            spotter.SetActive(true);
            spotter.transform.position = hit.point;
            if (_inputs.IsAiming)
            {
                aimingPanel.SetActive(true);
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
            else
            {
                aimingPanel.SetActive(true);
            }

        }
        else
        {
            spotter.transform.localPosition = _startSpotterPosition;
        }

    }
}
