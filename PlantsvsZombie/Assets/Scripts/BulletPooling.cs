using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    public static BulletPooling Instance;

    [SerializeField]
    private GameObject poolingObject;//오브젝트

    //오브젝트를 저장할 큐메모리
    private Queue<Bullet> poolingObjectQueue = new Queue<Bullet>();

    
    private void Awake()
    {
        Instance = this;
        Initialize(10);
    }
    
    private Bullet CreateNewObject()//새로운 오브젝트 생성하는 함수
    {
        var newobj = Instantiate(poolingObject, transform).GetComponent<Bullet>();
        newobj.gameObject.SetActive(false);
        return newobj;
    }

    private void Initialize(int count)//처음에 기본적으로 생성할 오브젝트 생성
    {
        for (int i = 0; i < count; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    public static Bullet GetObject() 
    {
        if(Instance.poolingObjectQueue.Count > 0)//남은 오브젝트가 있다면 안에 있는 오브젝트 꺼내서 줌
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else//없다면 큐에 추가해서 줌
        {
            var newobj = Instance.CreateNewObject();
            newobj.transform.SetParent(null);
            newobj.gameObject.SetActive(true);
            return newobj;
        }
    }

    public static void ReturnObject(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        bullet.transform.SetParent(Instance.transform);
        Instance.poolingObjectQueue.Enqueue(bullet);
    }

}
