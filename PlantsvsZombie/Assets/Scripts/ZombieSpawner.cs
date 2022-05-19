using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] SpawnPoint;
    private float time;
    private float spawnTime = 15f;
    [SerializeField]
    private GameObject Zombie;
    private void Start()
    {
        for (int i = 1; i < 7; i++)
        {
            Invoke("TimeMinus", i * 50);
        }
        for (int i = 1; i < 31; i++)
        {
            Invoke("SpawnZombie", i * 15);
        }
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;
        if (time == 300)
        {
            GameManager.Instance.lastWave = true;
            GameManager.Instance.islastWave = true;
            GameManager.Instance.LastWave.gameObject.SetActive(true);
            GameManager.Instance.LastWave.gameObject.SetActive(false);
        }
    }
    private void LateUpdate()
    {
        if(GameManager.Instance.lastWave == true)
        {
            for (int i = 0; i < 12; i++)
            {
                SpawnZombie();
            }
            GameManager.Instance.lastWave = false;
        }
        
    }
    private void TimeMinus()
    {
        spawnTime -= 1;
    }
    private void SpawnZombie()
    {
        Debug.Log("?");
        int randomPoint = Random.Range(0, 5);
        Instantiate(Zombie, SpawnPoint[randomPoint].transform.position, Quaternion.identity, GameObject.Find("Blocks").transform);
    }
}
