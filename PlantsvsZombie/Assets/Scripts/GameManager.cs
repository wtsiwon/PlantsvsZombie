using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    private static GameManager instance;
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
    [SerializeField] private Text time;
    [SerializeField] private Text Money;
    
    private void Start()
    {
        
    }

    
}
