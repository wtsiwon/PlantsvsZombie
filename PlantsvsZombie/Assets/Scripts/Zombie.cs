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
            isAttacking = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Plants"))
        {
            isAttacking = false;
        }
    }

    private void OnDestroy()
    {
        if(GameManager.Instance.lastWave == true)
        {
            GameManager.Instance.zombiecount--;
        }
    }

}