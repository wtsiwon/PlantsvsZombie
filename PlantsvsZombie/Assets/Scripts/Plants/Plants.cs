using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plants : MonoBehaviour
{
    [Header("기본")]
    [SerializeField] protected float hp;
    [SerializeField] protected float dmg;
    [SerializeField] protected float bulletspd;

    public int price;
    

    [Header("공격옵")]
    [SerializeField] protected float bulletInterval;
    [SerializeField] protected float bulletTime;

    protected abstract void Attack();
    private void Start()
    {
        InvokeRepeating("Attack", 1f, 1.5f);
    }
    protected void NormalPattern(Vector3 pos)
    {
        Bullet bullet = ObjPool.Instance.GetObj(pos);
        bullet.SetBullet(dmg, bullet.dir, bulletspd);
    }
}