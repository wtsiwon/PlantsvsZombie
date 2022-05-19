using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cherry : Plants
{
    [SerializeField]
    private Image ImageBoom;
    //3초뒤에 터지게 만들기
    protected override void Attack()
    {
        return;
    }
    private void Start()
    {
        Invoke("Boom",2.5f);
    }
    protected void Boom()//Cherry터짐
    {
        Instantiate(ImageBoom, transform.position, Quaternion.identity, GameObject.Find("Blocks").transform);
        Destroy(gameObject);
    }
}
