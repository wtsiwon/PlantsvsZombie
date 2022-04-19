using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectContainer : MonoBehaviour
{
    public bool isFull;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(gameObject.name);
        if (GameManager.Instance.draggingObject != null && isFull == false)
        {
            GameManager.Instance.currentContainer = this.gameObject;

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.Instance.currentContainer = null;
    }
}
