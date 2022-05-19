using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastWave : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie") && GameManager.Instance.lastWave)
        {
            Destroy(collision);
        }
    }
}
