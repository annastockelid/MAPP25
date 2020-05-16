using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject oneUp;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(oneUp,
            new Vector3(transform.position.x,
                         transform.position.y + 1f,
                         transform.position.z),
                          Quaternion.identity);
        Destroy(other.gameObject);
    }
}
