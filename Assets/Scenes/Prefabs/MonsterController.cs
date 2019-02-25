using UnityEngine;
using UnityEngine.AI;


public class MonsterController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject Goal;



    private void Start()
    {
      
    }
    // Update is called once per frame
    void Update()
    {
       
        agent.SetDestination(Goal.transform.position);
       
        

    }
        
    
}
