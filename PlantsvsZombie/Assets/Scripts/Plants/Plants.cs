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
    [Header("�⺻")]
    [SerializeField] protected float hp;
    [SerializeField] protected float dmg;
    [SerializeField] protected float bulletspd;

    public EPlantsType ePlantsType;
    public int price;
    protected bool isAttacked;

    [Header("���ݿ�")]
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
        }
    }
    protected void Update()
    {
        
    }
    #region �Ĺ� �Ѿ� �߻� ����
    protected void BasicPattern(Vector3 pos)//�⺻ �Ĺ� �ѹ߻�
    {
        Bullet bullet = ObjPool.Instance.Get<Bullet>(ePool_ObjType.BaseBullet, pos);
        bullet.SetBullet(dmg, bullet.dir, bulletspd, ePool_ObjType.BaseBullet);
    }
    protected void IcePattern(Vector3 pos)//���� �Ĺ� �ѹ߻�
    {
        Bullet bullet = ObjPool.Instance.Get<Bullet>(ePool_ObjType.IceBullet, pos);
        bullet.SetBullet(dmg, bullet.dir, bulletspd, ePool_ObjType.IceBullet);
    }
    protected void DoublePattern(Vector3 pos)//double �Ĺ� �ѹ߻�
    {
        Bullet bullet1 = ObjPool.Instance.Get<Bullet>(ePool_ObjType.BaseBullet, pos);
        StartCoroutine(CDoublePattern(pos));
    }
    IEnumerator CDoublePattern(Vector3 pos)//double 2��° �Ѿ�
    {
        yield return new WaitForSeconds(0.4f);
        Bullet bullet2 = ObjPool.Instance.Get<Bullet>(ePool_ObjType.BaseBullet, pos);
    }
    #endregion
}