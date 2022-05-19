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
            if (i == 30)
            {
                GameManager.Instance.lastWave = true;
                for (int j = 0; j < 12; j++)
                {
                    SpawnZombie();
                }
            }
        }
    }
    private void FixedUpdate()
    {
        time += Time.deltaTime;
    }
    private void TimeMinus()
    {
        spawnTime -= 1;
    }
    private void SpawnZombie()
    {
        int randomPoint = Random.Range(0, 5);
        Instantiate(Zombie, SpawnPoint[randomPoint].transform.position, Quaternion.identity, GameObject.Find("Blocks").transform);
    }
}
