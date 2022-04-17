using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public void MoneyAdd()
    {
        GameManager.Instance.Money += 25;
        Destroy(gameObject);
    }
}
