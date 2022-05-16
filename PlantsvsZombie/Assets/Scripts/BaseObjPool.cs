using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObjPool : Singleton<BaseObjPool>
{
    public Bullet Bullet;

    private Queue<Bullet> pool = new Queue<Bullet>();

    public Bullet GetObj()//pool에서 오브젝트를 가져온다
    {
        Bullet obj = null;
        if(pool.Count > 0)//있다면 줌
        {
            obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
        }
        else//없으면 생성해서 반환함
        {
            obj = Instantiate(Bullet, GameObject.FindGameObjectWithTag("Canvas").transform);
        }
        return obj;
    }

    public Bullet GetObj(Vector3 pos)//반환할 오브젝트에 위치값을 심어줌
    {
        Bullet obj = GetObj();
        obj.transform.position = pos;
        //obj.dir = dir;
        return obj;
    }

    public void ReturnObject(Bullet bullet)//다시 pool로 돌아오게하는 함수
    {
        pool.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}
