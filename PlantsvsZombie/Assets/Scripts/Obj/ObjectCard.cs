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
    public void OnDrag(PointerEventData eventData)//드레그 하는중의 나오는 오브젝의 위치는 마우스 위치다
    {
        objectDragInstace.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)//눌렀을때
    {
        objectDragInstace = Instantiate(object_Drag, canvas.transform);
        objectDragInstace.transform.position = Input.mousePosition;
        objectDragInstace.GetComponent<ObjectDragging>().card = this;

        GameManager.Instance.draggingObject = objectDragInstace;
    }
    
    public void OnPointerUp(PointerEventData eventData)//땠을때
    {
        switch (type)//식물 종류에 따라 가격설정
        {
            case Etype.Basic:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<BasicPlants>().price);
                break;
            case Etype.Ice:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<IcePlants>().price);
                break;
            case Etype.Money:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<BasicPlants>().price);//바꿔야댐
                break;
            case Etype.Stone:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<BasicPlants>().price);//바꿔야댐
                break;
            case Etype.Cherry:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<BasicPlants>().price);//바꿔야댐
                break;
            case Etype.Double:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<DoublePlants>().price);//바꿔야댐
                break;
        }
        GameManager.Instance.draggingObject = null;
        Destroy(objectDragInstace);
    }
}
