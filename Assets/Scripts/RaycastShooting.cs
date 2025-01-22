using UnityEngine;

public class RaycastShooting : MonoBehaviour
{
    
    [SerializeField] private float rayDistance = 100f;
    [SerializeField] private Transform redSpot;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = new Ray(transform.position, transform.forward * rayDistance);
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.magenta);

        if(Physics.Raycast(ray, out RaycastHit hit, rayDistance))
        {
            redSpot.gameObject.SetActive(true);
            redSpot.position = hit.point;

            hit.collider.gameObject.CompareTag();
            
            
            
        }
        else
        {
            redSpot.gameObject.SetActive(false);
        }
            

    }
}
