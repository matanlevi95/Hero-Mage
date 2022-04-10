using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            int currentSceneIndex =  SceneManager.GetActiveScene().buildIndex;
            if(SceneManager.GetSceneByBuildIndex(currentSceneIndex +1) != null)
            {
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
    }
}
