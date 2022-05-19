using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyText : MonoBehaviour
{
    public float moveSpeed;
    public float alphaSpeed;
    private TextMeshPro text;
    private Color alpha;
    public float destroyTime;
    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        text.text = "+25";
        alpha = text.color;
        Invoke("DestroyObject",destroyTime);
    }
    private void Update()
    {
        transform.Translate(new Vector3(0, moveSpeed * Time.deltaTime, 0));
        alpha.a = Mathf.Lerp(alpha.a, 0, Time.deltaTime * alphaSpeed);
        text.color = alpha;
    }
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
