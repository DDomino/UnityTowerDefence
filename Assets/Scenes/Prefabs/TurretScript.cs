using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{

    public Transform target;

    [Header("Attributes")]
    public float range = 5f;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag = "monster";
    public float turnspeed = 5f;

    public Transform partToRotate;
    public GameObject bulletPrefab;
    public Transform firePoint;

   


    void Start()
    {
        InvokeRepeating("Updatetarget", 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null) {return;}


        //target lockon;
        Vector3 pointDirection = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(pointDirection);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime *turnspeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y, 0f);



        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;

        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);

        }

    }

    void Updatetarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy; 
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
