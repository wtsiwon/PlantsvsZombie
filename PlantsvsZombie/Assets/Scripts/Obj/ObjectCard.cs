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
    public void OnDrag(PointerEventData eventData)//�巹�� �ϴ����� ������ �������� ��ġ�� ���콺 ��ġ��
    {
        objectDragInstace.transform.position = Input.mousePosition;
    }

    public void OnPointerDown(PointerEventData eventData)//��������
    {
        objectDragInstace = Instantiate(object_Drag, canvas.transform);
        objectDragInstace.transform.position = Input.mousePosition;
        objectDragInstace.GetComponent<ObjectDragging>().card = this;

        GameManager.Instance.draggingObject = objectDragInstace;
    }

    public void OnPointerUp(PointerEventData eventData)//������
    {
        switch (type)//�Ĺ� ������ ���� ���ݼ���
        {
            case Etype.Basic:
            case Etype.Ice:   
            case Etype.Money:       
            case Etype.Stone:       
            case Etype.Cherry:   
            case Etype.Double:
                GameManager.Instance.PlaceObject(object_Game.GetComponent<Plants>().price);//�ٲ�ߴ�
                break;
            default:
                Debug.Assert(false);
                break;
        }
        GameManager.Instance.draggingObject = null;
        Destroy(objectDragInstace);
    }
}