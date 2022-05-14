using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EZombieType
{
    Normal,
    Shield,
    Speed
}
public class Zombie : Obj
{
    [Header("±âº»")]
    [SerializeField] protected float hp;
    [SerializeField] protected float spd;
    [SerializeField] protected float dmg;
    [SerializeField] protected float attackSp;
    [SerializeField] protected float shield;
    


}