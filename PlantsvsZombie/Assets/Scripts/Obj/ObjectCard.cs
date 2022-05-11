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
        GameManager.Instance.PlaceObject(object_Game.GetComponent<BasicPlants>().price);
        GameManager.Instance.draggingObject = null;
        Destroy(objectDragInstace);
    }


    /*public void bubblesort()
    {
        int[] arr = new int[5];
        bool sorted = false;
        do
        {
            sorted = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    int temp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = temp;

                    sorted = true;
                }
            }
        } while (sorted);


    }*/
    
}
