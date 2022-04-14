using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Plants : MonoBehaviour
{
    [Header("기본")]
    [SerializeField] protected float hp;
    [SerializeField] protected Vector2 pos;

    [Header("공격옵")]
    [SerializeField] protected float bulletInterval;
    
    
}
