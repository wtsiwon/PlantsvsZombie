using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EZombieType
{
    Normal,
    Shield,
    Speed
}
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Zombie : Obj
{
    protected Rigidbody2D rb;
    public bool isAttacking;

    [Header("±âº»")]
    public float hp;
    public float spd;
    public float dmg;
    public float attackSp;
    public float shield;
    private float dspd;//defaultSpeed
    private float time;
    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        dspd = spd;
        rb.velocity = Vector3.left * spd;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Plants"))
        {
            rb.velocity = Vector3.left * 0;
        }
        if (collision.CompareTag("Bullet"))
        {
            hp -= collision.GetComponent<Bullet>().dmg;
        }
        if (collision.CompareTag("IceBullet"))
        {
            rb.velocity = Vector2.left * spd / 2;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Plants") && time >= attackSp)
        {
            isAttacking = true;
            Attack(collision);
            time = 0;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Plants"))
        {
            isAttacking = false;
            rb.velocity = Vector3.left * spd;
            spd = dspd;
        }
    }
    private void Update()
    {
        time += Time.deltaTime;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void Attack(Collider2D collision)
    {
        collision.GetComponent<Plants>().hp -= dmg;
    }
    private void OnDestroy()
    {
        if(GameManager.Instance.islastWave == true)
        {
            GameManager.Instance.zombiecount--;
        }
    }

}