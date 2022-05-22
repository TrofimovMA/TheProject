using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDestroy : MonoBehaviour
{
    private void Start()
    {

    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.gameObject.CompareTag("Player"))
            return;

        Destroy(Other.gameObject);
    }

}
