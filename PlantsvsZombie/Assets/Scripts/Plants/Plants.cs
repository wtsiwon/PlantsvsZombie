using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EPlantsType
{
    Basic,
    Ice,
    SunFlower,
    DoubleShooter,
    Stone,
    Boom
}
public abstract class Plants : Obj
{
    [Header("기본")]
    [SerializeField] protected float hp;
    [SerializeField] protected float dmg;
    [SerializeField] protected float bulletspd;

    public EPlantsType ePlantsType;
    public int price;

    [Header("공격옵")]
    [SerializeField] protected float bulletInterval;
    [SerializeField] protected float bulletTime;

    protected abstract void Attack();
    private void Start()
    {
        InvokeRepeating("Attack", 1f, 1.5f);
    }
    protected void BasicPattern(Vector3 pos)
    {
        Bullet bullet = ObjPool.Instance.Get<Bullet>(ePool_ObjType.BaseBullet, pos);
        bullet.SetBullet(dmg, bullet.dir, bulletspd, EBulletType.Basic);
    }
    protected void IcePattern(Vector3 pos)
    {
        Bullet bullet = ObjPool.Instance.Get<Bullet>(ePool_ObjType.IceBullet, pos);
        bullet.SetBullet(dmg, bullet.dir, bulletspd, EBulletType.Ice);
    }
    protected void DoublePattern(Vector3 pos)
    {
        Bullet bullet1 = ObjPool.Instance.Get<Bullet>(ePool_ObjType.BaseBullet, pos);
        StartCoroutine(CDoublePattern(pos));
        Bullet bullet2 = ObjPool.Instance.Get<Bullet>(ePool_ObjType.BaseBullet, pos);
    }
    IEnumerator CDoublePattern(Vector3 pos)
    {
        yield return new WaitForSeconds(0.2f);
    }
}