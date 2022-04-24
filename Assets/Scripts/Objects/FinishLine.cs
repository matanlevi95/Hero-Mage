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
            int numberOfLevels = SceneManager.sceneCount;
            int nextSceneIndex =  SceneManager.GetActiveScene().buildIndex+1;
            if(nextSceneIndex < numberOfLevels)
            {
                SceneManager.LoadScene(nextSceneIndex);
            }
        }
    }
}
