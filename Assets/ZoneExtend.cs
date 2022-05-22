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
    public GameObject gameManager;

    float sizeZ;

    private void Start()
    {
        sizeZ = RoadPartHalf.GetComponent<Renderer>().bounds.size.z;
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (!Other.gameObject.CompareTag("Player"))
            return;

        GameManager gm = gameManager.GetComponent<GameManager>();

        RoadFull.transform.position += new Vector3(0, 0, sizeZ);

        GameObject npc;
        if (Random.Range(0, 1 + 1) == 0)
        {
            npc = Instantiate(NPC1, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
        }
        else
        {
            npc = Instantiate(NPC1, SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
        }

        gm.addNPCtoList(npc);
    }
}
