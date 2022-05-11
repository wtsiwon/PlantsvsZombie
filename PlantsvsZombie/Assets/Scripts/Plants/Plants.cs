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
public enum EBulletType
{
    Base,
    Ice
}

public abstract class Plants : MonoBehaviour
{
    [Header("�⺻")]
    [SerializeField] protected float hp;
    [SerializeField] protected float dmg;
    [SerializeField] protected float bulletspd;

    public EPlantsType ePlantsType;
    public int price;
    

    [Header("���ݿ�")]
    [SerializeField] protected float bulletInterval;
    [SerializeField] protected float bulletTime;

    protected abstract void Attack();
    private void Start()
    {
        InvokeRepeating("Attack", 1f, 1.5f);
    }
    protected void BasicPattern(Vector3 pos)
    {
        Bullet bullet = BaseObjPool.Instance.GetObj(pos);
        bullet.SetBullet(dmg, bullet.dir, bulletspd);
    }
    protected void IcePattern(Vector3 pos)
    {

    }
}