using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ePool_ObjType
{
    BaseBullet,
    IceBullet,
    Money
}
public class ObjPool : Singleton<ObjPool>
{
    public ePool_ObjType type;//������Ʈ�� Ÿ���� �޴´�

    public Obj[] Origintypes;//���� ������Ʈ�� ������ Obj�� �迭�� �����.(����Ƽ �ν����Ϳ��� �־���)

    //��ųʸ���? 
    //��ųʸ��� Ű�� ���� �����ϴµ� �� Ű�� �����ϴ� ���� �ϳ� �����Ѵ�.
    //���� �θ����� �׿� ���� �ϴ� Ű�� �־�� �Ѵ�
    public Dictionary<ePool_ObjType, Queue<Obj>> pool = new Dictionary<ePool_ObjType, Queue<Obj>>();

    public Obj GetObj(ePool_ObjType type,Vector3 pos)
    {
        Obj obj = null;
        if (!pool.ContainsKey(type))//���ڷ� ���� Ÿ���� ������ �־��ش�.
        {
            pool.Add(type, new Queue<Obj>());
        }
        //��ųʸ� Ű�� �ִ� ť�� queue�� ����
        Queue<Obj> queue = pool[type];
        //����������Ʈ�� �޴´�
        Obj origin = Origintypes[(int)type];


        if (queue.Count > 0)//ť�� ������Ʈ�� ���� �ִٸ�
        {
            obj = queue.Dequeue();//ť���� ������
        }
        else//���ٸ� ������ ��
        {
            obj = Instantiate(origin);
        }
        obj.transform.position = pos;
        obj.gameObject.SetActive(true);
        return obj;
    }

    public T Get<T>(ePool_ObjType type,Vector3 pos)
        where T : MonoBehaviour
    {
        return GetObj(type, pos).GetComponent<T>();
    }
    public void Return(ePool_ObjType type, Obj obj)
    {
        obj.gameObject.SetActive(false);
        pool[type].Enqueue(obj);
    }

}
