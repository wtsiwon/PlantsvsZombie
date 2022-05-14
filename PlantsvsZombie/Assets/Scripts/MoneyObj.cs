using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyObj : Obj
{
    Rigidbody2D rb;
    [SerializeField] private float spd;
    private const int MONEY = 25;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.down * spd;
    }
    public void MoneyAdd()
    {
        GameManager.Instance.Money += MONEY;
        Destroy(gameObject);
    }

}
