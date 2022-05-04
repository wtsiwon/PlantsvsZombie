using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    [Header("���������Ʈ ��Ȳ")]
    public GameObject draggingObject;
    public GameObject currentContainer;

    [Space(20)]
    public GameObject MoneyObj;
    public Transform Spawnpoint;
    [SerializeField] private float startspawndel;//�� ��ȯ ���� ������
    [SerializeField] private float spawndelay;//�� ��ȯ ����

    private static GameManager instance;


    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        InvokeRepeating("Randomspawn", startspawndel, spawndelay);//��� �������� �� ��ȯ�ϱ�
    }
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }

    }
    //public GameObject RandomPoint()//���� ��� �������� �̱�
    //{
    //    GameObject randpoint = spawnpoints[Random.Range(0, spawnpoints.Count)];
    //    return randpoint;
    //}

    public void Randomspawn()//�� ��ȯ
    {
        int rand = Random.Range(600, 1600);
        Vector2 spawnpoint = new Vector2(rand, Spawnpoint.transform.position.y);
        Instantiate(MoneyObj, spawnpoint, MoneyObj.transform.rotation,GameObject.Find("Blocks").transform);
    }


    //[SerializeField] private Text timeSlider;
    [SerializeField] private Text moneyText;

    private float money;
    public float Money
    {
        get => money;
        set
        {
            money += value;
            moneyText.text = "Money: " + money.ToString();
        }
    }

    public void PlaceObject()//�Ĺ���ġ �ڵ�
    {//�巹�� �ϰ� �ְ� ���� �����̳ʰ� ������ ��ȯ�Ѵ�.
        if(draggingObject != null && currentContainer != null)
        {
            Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_Game, currentContainer.transform);
            currentContainer.GetComponent<ObjectContainer>().isFull = true;//��ȯ�� ĭ�� ä������ true;
        }
    }
}
