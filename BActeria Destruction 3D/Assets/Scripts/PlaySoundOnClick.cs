using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{

    public AudioSource sliceSound;

    public AudioSource beepSound;

    void Start()
    {
        beepSound = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sliceSound.Play();
        }
        
     
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Bacteria")
        {
            beepSound.Play();
        }
    }
}
