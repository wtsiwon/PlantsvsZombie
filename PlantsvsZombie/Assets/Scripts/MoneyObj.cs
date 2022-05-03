using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyObj : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float spd;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.down * spd;
    }
    public void MoneyAdd()
    {
        GameManager.Instance.Money += 25;
        Destroy(gameObject);
    }

}
