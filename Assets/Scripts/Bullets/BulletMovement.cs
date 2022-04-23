using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    Transform target;
    int minDamage;
    int maxDamage;
    [SerializeField] float bulletSpeed = 10f;

    // Start is called before the first frame update


    void FixedUpdate()
    {
        transform.LookAt(target);
        transform.position += transform.forward * Time.deltaTime * bulletSpeed;
    }

    public void SetData(Transform newTarget, int newMinDamage, int newMaxDamage)
    {
        target = newTarget;
        minDamage = newMinDamage;
        maxDamage = newMaxDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "PlayerBulletSpawnPosition" && other.tag != "Floor")
        {
            if (target)
            {
                if (other.tag == target.tag)
                {
                    int randomDamage = Random.Range(minDamage, maxDamage);
                    HealthSystem targetHealthSystem = target.GetComponent<HealthSystem>();
                    if (targetHealthSystem)
                    {
                        if (!targetHealthSystem.isDead) targetHealthSystem.TakeDamage(randomDamage);
                    }
                }
            }
            Destroy(gameObject);
        }
    }




}
