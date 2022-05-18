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
        //StartCoroutine(_Color());
        StartCoroutine(CBoom(transform.position, ImageBoom));
    }
    private IEnumerator _Color()
    {
        yield return new WaitForSeconds(2.5f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie"))
        {
            StartCoroutine(wait(collision));
        }
    }
    private IEnumerator wait(Collider2D collision)
    {
        yield return new WaitForSeconds(2.5f);
        //ImageBoom.transform.position = transform.position;
        //ImageBoom.gameObject.SetActive(true);
        Destroy(collision.gameObject);
    }
   
}
