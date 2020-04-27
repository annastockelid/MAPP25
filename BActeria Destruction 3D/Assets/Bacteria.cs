using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{

    public GameObject bacteriaSlicedPrefab;

    void OnTriggerEnter2D (Collider2D col)
    {
        if(col.tag == "Blade")
        {
            Instantiate(bacteriaSlicedPrefab);
            Destroy(gameObject);
        }
    }
}
