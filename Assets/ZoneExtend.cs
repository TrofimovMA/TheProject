using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneExtend : MonoBehaviour
{
    public GameObject RoadFull;
    public GameObject RoadPartHalf;
    public GameObject NPC1;
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;

    float sizeZ;

    private void Start()
    {
        sizeZ = RoadPartHalf.GetComponent<Renderer>().bounds.size.z;
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (!Other.gameObject.CompareTag("Player"))
            return;

        RoadFull.transform.position += new Vector3(0, 0, sizeZ);

        Instantiate(NPC1, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
    }

}
