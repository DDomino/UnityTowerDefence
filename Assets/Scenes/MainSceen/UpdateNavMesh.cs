using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UpdateNavMesh : MonoBehaviour
{
    public NavMeshSurface ground;
    void Start()
    {

        InvokeRepeating("UpdateMonsterRoute", 0f, 0.5f);


        

    }

    // Update is called once per frame
    void UpdaterMonsterRoute()
    {
        ground.BuildNavMesh();
    }
}
