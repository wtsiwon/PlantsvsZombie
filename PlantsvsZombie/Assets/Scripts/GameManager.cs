using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentContainer;
    public GameObject MoneyObj;
    public List<GameObject> spawnpoints = new List<GameObject>();

    private static GameManager instance;



    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        InvokeRepeating("Randomspawn", 5f, 5f);//°è¼Ó ·£´ýÀ¸·Î µ· ¼ÒÈ¯ÇÏ±â
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
    //public GameObject RandomPoint()//½ºÆù Àå¼Ò ·£´ýÀ¸·Î »Ì±â
    //{
    //    GameObject randpoint = spawnpoints[Random.Range(0, spawnpoints.Count)];
    //    return randpoint;
    //}

    public void Randomspawn()
    {
        int rand = Random.Range(0, spawnpoints.Count);
        Instantiate(MoneyObj, spawnpoints[rand].transform.position, MoneyObj.transform.rotation);//µ· ¼ÒÈ¯
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
            moneyText.text += money;
        }
    }

    public void PlaceObject()
    {
        if(draggingObject != null && currentContainer != null)
        {
            Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_Game, currentContainer.transform);
            currentContainer.GetComponent<ObjectContainer>().isFull = true;
        }
    }
}
