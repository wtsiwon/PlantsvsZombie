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
    protected override void Attack()//�� �����ϴ� ���̶� ���� ���� ����
    {
        return;
    }
    private void Start()
    {
        InvokeRepeating("Money", instantiateTime, instantiateTime);
    }
    private void Money()//Boom�̹���
    {
        Instantiate(text, transform.position, Quaternion.identity,GameObject.Find("Blocks").transform);
        GameManager.Instance.Money += 25;
    }
}
