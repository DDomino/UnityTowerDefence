using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeSpawnScript : MonoBehaviour
{
    public int rowAmount = 1;
    public GameObject nodeRow;
    int zPos = 30;

    void Start()
    {
        for (int i = 0; i < rowAmount; i++)
        {
            Instantiate(nodeRow, new Vector3(0, 0.1f, zPos), Quaternion.identity);
            zPos -= 4;
        }
    }
}
