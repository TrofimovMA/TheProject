using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDestroy : MonoBehaviour
{
    public GameManager gameManager;

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player"))
            return;

        GameManager gm = gameManager.GetComponent<GameManager>();
        gm.deleteNPCtoList(Other.gameObject);

        Destroy(Other.gameObject);
    }

}
