using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomImage : MonoBehaviour
{
    private void Start()
    {
        Invoke("InDestroy", 1f);
    }
    private void InDestroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            Destroy(collision.gameObject);
        }
    }
}
