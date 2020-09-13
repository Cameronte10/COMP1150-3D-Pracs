using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{
    //avoid everything
    //rays
    public float distance, minSpeed, maxSpeed, speed;
    Transform rayPoint;
    LayerMask mask;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        mask = LayerMask.GetMask("Default");
        rayPoint = transform.Find("RayPoint").GetComponent<Transform>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
        //rb.AddForce(transform.forward * speed);
        RayCheck();
    }

    void RayCheck()
    {
        RaycastHit hit;
        Physics.Raycast(rayPoint.position, transform.forward, out hit, distance, mask);
        Debug.DrawRay(rayPoint.position, transform.forward + Vector3.right, Color.black);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.gameObject);
        }
    }
}
