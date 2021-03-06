﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
    public GameObject bacteraSlicedPrefab;





    Rigidbody2D rb;
    public float startForce = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);



    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {

            ScoreScript.Instance.IncrementScore(1);


            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation =  Quaternion.LookRotation(direction);

            GameObject slicedBacteria =  Instantiate(bacteraSlicedPrefab, transform.position, rotation);

            Destroy(slicedBacteria, 3f);
            Destroy(gameObject);
           
        }

    }


}
