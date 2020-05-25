using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnClick : MonoBehaviour
{

    public AudioSource sliceSound;
 


    void Start()
    {
   
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            sliceSound.Play();
        }
       
    }


}
