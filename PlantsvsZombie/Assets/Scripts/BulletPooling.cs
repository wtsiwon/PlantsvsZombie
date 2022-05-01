using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPooling : MonoBehaviour
{
    public static BulletPooling Instance;

    [SerializeField]
    private GameObject poolingObject;//������Ʈ

    //������Ʈ�� ������ ť�޸�
    private Queue<Bullet> poolingObjectQueue = new Queue<Bullet>();

    
    private void Awake()
    {
        Instance = this;
        Initialize(10);
    }
    
    private Bullet CreateNewObject()//���ο� ������Ʈ �����ϴ� �Լ�
    {
        var newobj = Instantiate(poolingObject, transform).GetComponent<Bullet>();
        newobj.gameObject.SetActive(false);
        return newobj;
    }

    private void Initialize(int count)//ó���� �⺻������ ������ ������Ʈ ����
    {
        for (int i = 0; i < count; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());
        }
    }

    public static Bullet GetObject() 
    {
        if(Instance.poolingObjectQueue.Count > 0)//���� ������Ʈ�� �ִٸ� �ȿ� �ִ� ������Ʈ ������ ��
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else//���ٸ� ť�� �߰��ؼ� ��
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
