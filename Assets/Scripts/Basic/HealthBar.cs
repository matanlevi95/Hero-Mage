using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Transform healthBarCanvas;
    void Update()
    {
        healthBarCanvas.eulerAngles = Camera.main.transform.eulerAngles;    
    }
}
