using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5, underwaterSpeed = 20, underwaterGravity;
    Vector3 velocity;
    public Rigidbody rb;
    public UnderwaterContoller underwaterContoller;

    void Update()
    {
        if (underwaterContoller.underwater)
        {
            rb.AddForce(Vector3.up * Input.GetAxis("Jump") * underwaterSpeed * Time.deltaTime, ForceMode.VelocityChange);
            rb.AddForce(-Vector3.up * Input.GetAxis("Crouch") * underwaterSpeed * Time.deltaTime);
            rb.AddForce(-transform.up * underwaterGravity);
        }
            velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;

            transform.Translate(velocity.x, 0, velocity.y);
        
    }
}
