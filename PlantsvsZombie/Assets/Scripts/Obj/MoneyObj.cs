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
        ObjPool.Instance.Return(pooltype,this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DestroyZone"))
        {
            ObjPool.Instance.Return(pooltype, this);
        }
    }

}
