﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public GameObject oneDown;
    public GameObject oneUp;
    public GameObject bladeTrailPrefab;
    public float minCuttingVelocity = .001f;
    public PauseMenu pauseMenu;
    public AudioSource beepSound;
    public AudioSource buzzSound;
	public AudioSource bombSound;


	private Shake shake;
 

    bool isCutting = false;

    Vector2 previousPosition;

    GameObject currentBladeTrail; 

    Rigidbody2D rb;
    Camera cam;
    CircleCollider2D circleCollider;

    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();

        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        } else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if (velocity > minCuttingVelocity)
        {
            circleCollider.enabled = true;
        } else
        {
            circleCollider.enabled = false;
        }
       
        previousPosition = newPosition;
    }

    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        circleCollider.enabled = false;

    }

    void StopCutting()
    {
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
        circleCollider.enabled = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {


        if(other.tag == "Pill")
        {
            Instantiate(oneDown,
                 new Vector3(transform.position.x,
                             transform.position.y + 1f,
                             transform.position.z),
                             Quaternion.identity);
            buzzSound.Play();
            shake.CamShake();

        }

        else if (other.tag == "Bacteria")
        {
            Instantiate(oneUp,
                 new Vector3(transform.position.x,
                             transform.position.y + 1f,
                             transform.position.z),
                             Quaternion.identity);
            beepSound.Play();
        }

        else if (other.tag == "Bomb")
        {
            pauseMenu.GameOver();
			bombSound.Play();


		}

    }
    
}
