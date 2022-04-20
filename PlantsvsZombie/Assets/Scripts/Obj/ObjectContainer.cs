using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectContainer : MonoBehaviour
{
    public bool isFull;
    public Image backgroundImage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (GameManager.Instance.draggingObject != null && isFull == false)
        {
            GameManager.Instance.currentContainer = this.gameObject;
            backgroundImage.enabled = true;

        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        GameManager.Instance.currentContainer = null;
        backgroundImage.enabled = false;
    }
}
