﻿

using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public GameObject impactEffect;
    public float speed = 70f;

    public void Seek(Transform _target)
    {
        target = _target;
    }


    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {

        GameObject effetcIns= (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effetcIns, 2f);
        Destroy(gameObject);
    }

}