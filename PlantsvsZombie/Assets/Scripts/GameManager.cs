using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public GameObject draggingObject;
    public GameObject currentContainer;
    private static GameManager instance;
    private void Awake()
    {
        instance = this;
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

    // [SerializeField] private Text timeText;
    //[SerializeField] private Text moneyText;

    private float money;
    public float Money
    {
        get => money;
        set
        {

        }
    }

    public void PlaceObject()
    {

    }




}
