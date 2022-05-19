using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyPlants : Plants
{
    [SerializeField]
    private float instantiateTime;
    [SerializeField]
    private TextMeshPro text;
    protected override void Attack()//돈 생산하는 놈이라 공격 패턴 없음
    {
        return;
    }
    private void Start()
    {
        InvokeRepeating("Money", instantiateTime, instantiateTime);
    }
    private void Money()//Boom이미지
    {
        Instantiate(text, transform.position, Quaternion.identity,GameObject.Find("Blocks").transform);
        GameManager.Instance.Money += 25;
    }
}
