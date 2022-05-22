using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject Car;
    public GameObject Camera;

    Rigidbody rb;
    private Vector3 cam_offset;

    public float speed = 6f;
    public float xspeed = 3f;
    public Vector2 xbounds = new Vector2(-2f, -2f);

    void Start()
    {
        rb = Car.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, speed);

        cam_offset = Camera.transform.position - Car.transform.position;
    }

    void FixedUpdate()
    {
        float step = xspeed;
        if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            step *= -1;
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            step = 0f;
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            step = 0f;

        rb.velocity = new Vector3(step, 0, speed);

        // rb.velocity = Vector3.forward * speed;
        // rb.AddForce(new Vector3(Input.GetAxis("Horizontal") * xspeed, 0, speed), ForceMode.VelocityChange);


        //Vector3 oldPos = transform.position;
        //transform.position = new Vector3(Mathf.Clamp(oldPos.x, xbounds.x, xbounds.y), oldPos.y, oldPos.z);
        // Input.GetAxis("Horizontal") *xspeed

        //var direction = new Vector3(0, 0, hor).normalized;
        //direction *= hspeed * Time.deltaTime;

        //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * xspeed, 0, speed);
        // Vector3 pos = transform.position;
        // Debug.Log($"{pos.x} / {Mathf.Clamp(pos.x, xbounds.x, xbounds.y)}");
        //if (pos.x != Mathf.Clamp(pos.x, xbounds.x, xbounds.y))
        //{
        //    rb.velocity = new Vector3(0, 0, speed);
        //    transform.position = new Vector3(Mathf.Clamp(pos.x, xbounds.x, xbounds.y), pos.y, pos.z);
        //}
        //else
        //{

        //float step = xspeed;
        //if (Input.GetAxis("Horizontal") < 0)
        //    step *= -1;
        //Debug.Log(Mathf.Abs(Mathf.Clamp(pos.x + step, xbounds.x, xbounds.y) - pos.x));
        //if (Mathf.Abs(Mathf.Clamp(pos.x + step, xbounds.x, xbounds.y) - pos.x)>0.0001)
        //{
        //    pos.x = Mathf.Clamp(pos.x + step, xbounds.x, xbounds.y);
        //    rb.velocity = new Vector3(0, 0, speed);
        //}
        //else
        //{
        //    rb.velocity = new Vector3(step, 0, speed);
        //}

        //rb.velocity = new Vector3(Mathf.Clamp(pos.x + step, xbounds.x, xbounds.y) - pos.x, 0, speed);
        //}
        // Vector3 oldPos = transform.position;
        // transform.position = new Vector3(Mathf.Clamp(oldPos.x, xbounds.x, xbounds.y), oldPos.y, oldPos.z);
    }

    void Update()
    {
        Vector3 pos = Car.transform.position;
        pos = new Vector3(Mathf.Clamp(pos.x, xbounds.x, xbounds.y), pos.y, pos.z);
        Car.transform.position = pos;
    }

    void LateUpdate()
    {
        Camera.transform.position = Car.transform.position + cam_offset;
    }
}
