﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{

    public GameObject hazardSlicedPrefab;

    Rigidbody2D rb;
    public float startForce = 15f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            ScoreScript.scoreValue -= 1; //Lägger till 1 på poäng

            Vector3 direction = (col.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            GameObject slicedHazard = Instantiate(hazardSlicedPrefab, transform.position, rotation);
            Destroy(slicedHazard, 3f);
            Destroy(gameObject);
        }
    }
}
