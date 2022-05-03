using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantsType
{

}
public abstract class Plants : MonoBehaviour
{
    

    
    [Header("�⺻")]
    [SerializeField] protected float hp;
    [SerializeField] protected float dmg;
    [SerializeField] protected float bulletspd;
    

    [Header("���ݿ�")]
    [SerializeField] protected float bulletInterval;
    [SerializeField] protected float bulletTime;


    [SerializeField] private Bullet bulletObj;
    [SerializeField] private Transform firePos;

    
    protected abstract void Attack();

    
    protected void NormalPattern()
    {
        Bullet bullet = BulletPooling.GetObject();
        bullet.SetBullet(dmg, bulletObj.dir, bulletspd);
    }
    

    
}