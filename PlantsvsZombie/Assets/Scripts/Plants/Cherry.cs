using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cherry : Plants
{
    [SerializeField]
    private Image ImageBoom;
    //3�ʵڿ� ������ �����
    protected override void Attack()
    {
        return;
    }
    private void Start()
    {
        Invoke("Boom",2.5f);
    }
    protected void Boom()//Cherry����
    {
        Instantiate(ImageBoom, transform.position, Quaternion.identity, GameObject.Find("Blocks").transform);
        Destroy(gameObject);
    }
}
