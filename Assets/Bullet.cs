

using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;


    public GameObject impactEffect;
    public float speed = 70f;
    public float explotionRadius = 0f;

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
        transform.LookAt(target);
    }

    void HitTarget()
    {

        GameObject effetcIns= (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        
        Destroy(effetcIns, 2f);

        if(explotionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    void Explode()
    {
      Collider[] enemyColliders =  Physics.OverlapSphere(transform.position, explotionRadius);
        foreach(Collider collider in enemyColliders)
        {
            if (collider.tag == "monster")
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, explotionRadius);
    }
}
