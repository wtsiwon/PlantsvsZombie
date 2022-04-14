using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantsType
{

}
public abstract class Plants : MonoBehaviour
{
    Tile tile;

    
    [Header("기본")]
    [SerializeField] protected float hp;
    [SerializeField] protected int[,] pos = new int[5, 7];

    [Header("공격옵")]
    [SerializeField] protected float bulletInterval;
    

    
}


public struct Tile
{
    int x;
    int y;
}
