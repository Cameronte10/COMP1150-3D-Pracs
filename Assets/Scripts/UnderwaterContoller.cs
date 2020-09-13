using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterContoller : MonoBehaviour
{
    //shrink player
    //remove gravity
    //turn off jump and use space as upward force
    //turn off crouch and use ctrl as downward force

    public bool underwater;
    public Rigidbody rb;
    public Jump jump;
    public Crouch crouch;
    public AudioSource audio, ambient;
    public AudioClip enter, exit, ambientClip;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = GetComponent<Jump>();
        crouch = GetComponent<Crouch>();
        ambient.clip = ambientClip;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            underwater = true;
            SwitchState();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            underwater = false;
            SwitchState();
        }
    }

    public void SwitchState()
    {
        if (underwater)
        {
            //scale
            transform.localScale.Set(transform.localScale.x, transform.localScale.y / 2, transform.localScale.z);
            //disable crouch/jump
            jump.enabled = false;
            crouch.enabled = false;
            rb.useGravity = false;
            StartCoroutine(VelocityChange(rb.velocity, rb.velocity / 3));
            rb.drag = 1;
            audio.clip = enter;
            audio.Play();
            
            ambient.Play();
        }
        else
        {
            //scale
            transform.localScale.Set(transform.localScale.x, transform.localScale.y * 2, transform.localScale.z);
            //disable crouch/jump
            jump.enabled = true;
            crouch.enabled = true;
            rb.useGravity = true;
            audio.clip = exit;
            audio.Play();
            ambient.Pause();
        }
    }

    IEnumerator VelocityChange(Vector3 velocity, Vector3 velocityDiv)
    {
        Vector3 vel = velocity;
        while(vel != velocityDiv)
        {
            vel = Vector3.Lerp(velocity, velocityDiv, Time.deltaTime * 3);
            yield return new WaitForFixedUpdate();
        }

        yield break;
    }
}
