using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    
    [SerializeField] private float speed;

    private Rigidbody _rb;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 velocity = new Vector3(0, _rb.linearVelocity.y, 0);
        velocity += transform.forward * speed;
        _rb.linearVelocity = velocity;
        
        //_rb.linearVelocity = transform.forward * (speed * Time.deltaTime);
        
    }
}
