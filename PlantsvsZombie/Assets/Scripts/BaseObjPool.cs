using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObjPool : Singleton<BaseObjPool>
{
    public Bullet Bullet;

    private Queue<Bullet> pool = new Queue<Bullet>();

    public Bullet GetObj()//pool���� ������Ʈ�� �����´�
    {
        Bullet obj = null;
        if(pool.Count > 0)//�ִٸ� ��
        {
            obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
        }
        else//������ �����ؼ� ��ȯ��
        {
            obj = Instantiate(Bullet, GameObject.FindGameObjectWithTag("Canvas").transform);
        }
        return obj;
    }

    public Bullet GetObj(Vector3 pos)//��ȯ�� ������Ʈ�� ��ġ���� �ɾ���
    {
        Bullet obj = GetObj();
        obj.transform.position = pos;
        //obj.dir = dir;
        return obj;
    }

    public void ReturnObject(Bullet bullet)//�ٽ� pool�� ���ƿ����ϴ� �Լ�
    {
        pool.Enqueue(bullet);
        bullet.gameObject.SetActive(false);
    }
}
