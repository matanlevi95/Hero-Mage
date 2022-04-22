using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBulletRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;
    [SerializeField] Transform target;
    void Update()
    {
        transform.RotateAround(target.position, new Vector3(0,1,1), rotationSpeed * Time.deltaTime);    
    }
}
