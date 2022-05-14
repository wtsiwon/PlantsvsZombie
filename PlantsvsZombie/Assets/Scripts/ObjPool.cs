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
    public ePool_ObjType type;

    public Obj[] Origintypes;

    public Dictionary<ePool_ObjType, Queue<Obj>> pool = new Dictionary<ePool_ObjType, Queue<Obj>>();

    public Obj GetObj(ePool_ObjType type)
    {
        Obj obj = null;
        if (!pool.ContainsKey(type))
        {
            pool.Add(type, new Queue<Obj>());
        }
      

        return obj;
    }

}
