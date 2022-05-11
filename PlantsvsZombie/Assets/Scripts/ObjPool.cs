using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjPool : Singleton<ObjPool>
{
    public Bullet Bullet;

    private Queue<Bullet> pool = new Queue<Bullet>();

    public Bullet GetObj()
    {
        Bullet obj = null;
        if(pool.Count > 0)
        {
            obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
        }
        else
        {
            obj = Instantiate(Bullet, GameObject.FindGameObjectWithTag("Canvas").transform);
        }
        return obj;
    }

    public Bullet GetObj(Vector3 pos)
    {
        Bullet obj = GetObj();
        obj.transform.position = pos;
        //obj.dir = dir;
        return obj;
    }

    public void ReturnObject(Bullet bullet)
    {
        pool.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}
