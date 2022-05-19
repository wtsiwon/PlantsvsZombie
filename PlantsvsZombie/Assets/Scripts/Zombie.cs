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

    [Header("±âº»")]
    public float hp;
    public float spd;
    public float dmg;
    public float attackSp;
    public float shield;
    private void Start()
    {
        rb.velocity = Vector3.left * spd;
    }


}