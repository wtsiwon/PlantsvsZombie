using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameManager : Singleton<GameManager>
{
    [Header("현재오브젝트 상황")]
    public GameObject draggingObject;
    public GameObject currentContainer;

    [Space(20)]
    public GameObject MoneyObj;
    public Transform Spawnpoint;
    public bool isEnd;
    public bool lastWave;
    public int zombiecount = 12;
    [SerializeField] private float startspawndel;//돈 소환 시작 딜레이
    [SerializeField] private float spawndelay;//돈 소환 간격

    private void Start()
    {
        InvokeRepeating("Randomspawn", startspawndel, spawndelay);//계속 랜덤으로 돈 소환하기
    }
    //public GameObject RandomPoint()//스폰 장소 랜덤으로 뽑기
    //{
    //    GameObject randpoint = spawnpoints[Random.Range(0, spawnpoints.Count)];
    //    return randpoint;
    //}

    public void Randomspawn()//돈 소환
    {
        int rand = Random.Range(800, 1600);
        Vector2 spawnpoint = new Vector2(rand, Spawnpoint.transform.position.y);
        ObjPool.Instance.Get<MoneyObj>(ePool_ObjType.Money, spawnpoint);
        //Instantiate(MoneyObj, spawnpoint, MoneyObj.transform.rotation,GameObject.Find("Blocks").transform);
    }

    private void Update()
    {
        if(zombiecount == 0)
        {

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Money += 100;
        }
    }
    //[SerializeField] private Text timeSlider;
    [SerializeField] private Text moneyText;

    private float money;
    public float Money
    {
        get => money;
        set
        {
            money = value;
            moneyText.text = "Money: " + money.ToString();
        }
    }

    public void PlaceObject(int price)//식물설치 코드
    {
        //드레그 하고 있고 닿은 컨테이너가 있으면 소환한다.
        if (draggingObject != null && currentContainer != null && money >= price)
        {
            Money -= price;
            Instantiate(draggingObject.GetComponent<ObjectDragging>().card.object_Game, currentContainer.transform);
            currentContainer.GetComponent<ObjectContainer>().isFull = true;//소환후 칸이 채워졋다 true;
        }
    }
    public void BadEnding()
    {
        SceneManager.LoadScene("BadEnding");
    }
    public void HappyEnding()
    {
        SceneManager.LoadScene("HappyEnding");
    }
}
