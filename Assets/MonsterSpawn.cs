using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterSpawn : MonoBehaviour
{
    public NavMeshAgent agent;


    public Transform spawnPoint;
    private float timeBetweenWaves = 10.5f;
    private float countdown = 2f;



    public Text WaveCountdownText;

    private int waveIndex = 0;

        void Update()
    {
        if (countdown <= 0f) {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves+waveIndex;
        }
        else {
            countdown -= Time.deltaTime;
            WaveCountdownText.text = Mathf.Round(countdown).ToString();
            Debug.Log(countdown);
        }
   ;
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.8f);
        }
     

    }
    void SpawnEnemy()
    {
        Instantiate(agent, spawnPoint.position, spawnPoint.rotation);
    }




}

