using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlantsType
{

}
public abstract class Plants : MonoBehaviour
{
    Tile tile;

    
    [Header("�⺻")]
    [SerializeField] protected float hp;
    [SerializeField] protected int[,] pos = new int[5, 7];

    [Header("���ݿ�")]
    [SerializeField] protected float bulletInterval;

    private void Start()
    {
        
    }
    protected abstract void Attack();

    protected void NormalPattern()
    {
        
        
    }
    

    
}


public struct Tile
{
    int x;
    int y;
}
