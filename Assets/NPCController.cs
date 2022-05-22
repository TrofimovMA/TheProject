using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public GameObject Car;
    Rigidbody rb;

    public float speed = 6f;
    public float xspeed = 3f;
    public Vector2 xbounds = new Vector2(-2f, -2f);

    void Start()
    {
        rb = Car.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0, 0, speed);

    }

    void Update()
    {
        
    }
}
