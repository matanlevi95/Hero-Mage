using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBulletRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    public Transform target;

    void FixedUpdate()
    {
        transform.RotateAround(target.position, new Vector3(1,1,1), rotationSpeed * Time.deltaTime);    
    }
}
