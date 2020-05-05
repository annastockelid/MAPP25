using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int startingLives;
    private int lifeCounter;

    private Text theText;

    void Start()
    {
        theText = GetComponent<Text>();

        lifeCounter = startingLives;

    }

    // Update is called once per frame
    void Update()
    {
        theText.text = "x " + lifeCounter;

    }

    public void TakeLife() 
    {
        lifeCounter--;
    }
}
