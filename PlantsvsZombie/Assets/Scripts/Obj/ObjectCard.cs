using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public enum Etype
{
    Basic,
    Ice,
    Money,
    Stone,
    Cherry,
    Double,
}
public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject object_Drag;
    public GameObject object_Game;
    public Canvas canvas;
    private GameObject objectDragInstace;
    public Etype type;
    public void OnDrag(PointerEventData eventData)//µå·¹±× ÇÏ´ÂÁßÀÇ ³ª¿À´Â ¿ÀºêÁ§ÀÇ À§Ä¡´Â ¸¶¿ì½º À§Ä¡´Ù
    {
        objectDragInstace.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)//´­·¶À»¶§
    {
        objectDragInstace = Instantiate(object_Drag, canvas.transform);
        objectDragInstace.transform.position = Input.mousePosition;
        objectDragInstace.GetComponent<ObjectDragging>().card = this;

        GameManager.Instance.draggingObject = objectDragInstace;
    }
    
    public void OnPointerUp(PointerEventData eventData)//¶®À»¶§
    {
        switch (type)
        {
            case Etype.Basic:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<BasicPlants>().price);
                break;
            case Etype.Ice:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<IcePlants>().price);
                break;
            case Etype.Money:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<BasicPlants>().price);//¹Ù²ã¾ß´ï
                break;
            case Etype.Stone:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<BasicPlants>().price);//¹Ù²ã¾ß´ï
                break;
            case Etype.Cherry:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<BasicPlants>().price);//¹Ù²ã¾ß´ï
                break;
            case Etype.Double:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<BasicPlants>().price);//¹Ù²ã¾ß´ï
                break;
        }
        GameManager.Instance.draggingObject = null;
        Destroy(objectDragInstace);
    }
}
