using UnityEngine;
using UnityEngine.EventSystems;
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
            case Etype.Ice:   
            case Etype.Money:       
            case Etype.Stone:       
            case Etype.Cherry:   
            case Etype.Double:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<Plants>().price);//바꿔야댐
                break;
            default:
                Debug.Assert(false);
                break;
        }
        GameManager.Instance.draggingObject = null;
        Destroy(objectDragInstace);
    }
}