using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] private float timeToDeath = 1;

    void Start()
    {
        StartCoroutine(DeathTime()); 
    }

    private IEnumerator DeathTime()
    {
        yield return new WaitForSeconds(timeToDeath);
        Destroy(gameObject);
    }

    
}
