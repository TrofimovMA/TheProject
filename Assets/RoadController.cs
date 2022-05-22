using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public GameObject RoadFull;
    public GameObject RoadPartHalf;

    float sizeZ;

    private void Start()
    {
        sizeZ = RoadPartHalf.GetComponent<Renderer>().bounds.size.z;
    }

    private void OnTriggerEnter(Collider Other)
    {
        RoadFull.transform.position += new Vector3(0, 0, sizeZ);
    }

}
