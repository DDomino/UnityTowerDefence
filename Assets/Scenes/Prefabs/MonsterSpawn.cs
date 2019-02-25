using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterSpawn : MonoBehaviour
{
    public NavMeshAgent agent;
  
    public int pooledAmount;
    List<NavMeshAgent> agents;

    void Start()
    {

   agents = new List<NavMeshAgent>();
   
      for (int i = 0; i < pooledAmount; i++)
        {
          
           NavMeshAgent newAgent = (NavMeshAgent)Instantiate(agent);
           newAgent.gameObject.SetActive(false);
          agents.Add(newAgent);
        }

       InvokeRepeating("Spawn", 2f,0.01f);
        

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    

    void Spawn()
    {
        for (int i = 0; i < agents.Count; ++i) {

            if (!agents[i].gameObject.activeInHierarchy)
            {
                agents[i].transform.position = transform.position;
                agents[i].gameObject.SetActive(true);
                break;
            }
        }

    }
}
