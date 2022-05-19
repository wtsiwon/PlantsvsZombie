using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public float hp;
    public float dmg;
    public float bulletspd;

    public EPlantsType ePlantsType;
    public int price;
    protected bool isAttacked;

    [Header("공격옵")]
    [SerializeField] protected float bulletInterval;
    [SerializeField] protected float bulletTime;

    
    protected abstract void Attack();
    private void Start()
    {
        InvokeRepeating("Attack", 1f, 1.5f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            isAttacked = true;
            if(hp <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    protected void Update()
    {
        
    }
    #region 식물 총알 발사 패턴
    protected void BasicPattern(Vector3 pos)//기본 식물 총발사
    {
        Bullet bullet = ObjPool.Instance.Get<Bullet>(ePool_ObjType.BaseBullet, pos);
        bullet.SetBullet(dmg, bullet.dir, bulletspd, ePool_ObjType.BaseBullet);
    }
    protected void IcePattern(Vector3 pos)//얼음 식물 총발사
    {
        Bullet bullet = ObjPool.Instance.Get<Bullet>(ePool_ObjType.IceBullet, pos);
        bullet.SetBullet(dmg, bullet.dir, bulletspd, ePool_ObjType.IceBullet);
    }
    protected void DoublePattern(Vector3 pos)//double 식물 총발사
    {
        Bullet bullet1 = ObjPool.Instance.Get<Bullet>(ePool_ObjType.BaseBullet, pos);
        StartCoroutine(CDoublePattern(pos));
    }
    IEnumerator CDoublePattern(Vector3 pos)//double 2번째 총알
    {
        yield return new WaitForSeconds(0.4f);
        Bullet bullet2 = ObjPool.Instance.Get<Bullet>(ePool_ObjType.BaseBullet, pos);
    }
    #endregion
}