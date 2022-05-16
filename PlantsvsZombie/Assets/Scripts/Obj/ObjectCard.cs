using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectCard : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public GameObject object_Drag;
    public GameObject object_Game;
    public Canvas canvas;
    private GameObject objectDragInstace;
    

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
        GameManager.Instance.PlaceObject(object_Game.GetComponent<BasicPlants>().price);
        GameManager.Instance.draggingObject = null;
        Destroy(objectDragInstace);
    }
}
