using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHP : MonoBehaviour
{
    int goalHP = 50;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "monster")
        {
            goalHP -= 1;
            print(goalHP);
            Destroy(other.gameObject);
           //other.gameObject.SetActive(false);

        }
    }
}
