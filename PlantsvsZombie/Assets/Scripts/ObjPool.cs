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
    public ePool_ObjType type;//오브젝트의 타입을 받는다

    public Obj[] Origintypes;//실제 오브젝트를 저장할 Obj형 배열을 만든다.(유니티 인스펙터에서 넣어줌)

    //딕셔너리란? 
    //딕셔너리는 키와 값이 존재하는데 꼭 키에 대응하는 값이 하나 존재한다.
    //값을 부르려면 그에 대응 하는 키를 넣어야 한다
    public Dictionary<ePool_ObjType, Queue<Obj>> pool = new Dictionary<ePool_ObjType, Queue<Obj>>();

    public Obj GetObj(ePool_ObjType type,Vector3 pos)
    {
        Obj obj = null;
        if (!pool.ContainsKey(type))//인자로 넣은 타입이 없으면 넣어준다.
        {
            pool.Add(type, new Queue<Obj>());
        }
        //딕셔너리 키에 있는 큐를 queue로 정의
        Queue<Obj> queue = pool[type];
        //실제오브젝트를 받는다
        Obj origin = Origintypes[(int)type];


        if (queue.Count > 0)//큐에 오브젝트가 남이 있다면
        {
            obj = queue.Dequeue();//큐에서 빼서줌
        }
        else//없다면 스폰후 줌
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
