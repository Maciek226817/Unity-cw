using UnityEngine;

public class Zadanie6 : MonoBehaviour
{
    public float speed = 2.0f;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

    }
    void FixedUpdate()
    {
        float mH = Input.GetAxis("Horizontal");
        float mV = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(mH, 0, mV);
        velocity = velocity.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + velocity);

        Vector3 targetPosition = transform.position + velocity;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}