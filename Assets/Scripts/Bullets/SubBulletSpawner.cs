using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBulletSpawner : MonoBehaviour
{
    CharacterStats playerStats;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject) playerStats = playerObject.GetComponent<CharacterStats>();
        else Destroy(gameObject);

        HandleSubBullets();

    }

    void HandleSubBullets()
    {
        for (int i = 0; i < playerStats.spellsAbillities.Count; i++)
        {
            CreateSubBulletByType(playerStats.spellsAbillities[i]);
        }
    }

    private void CreateSubBulletByType(Transform bolt)
    {
        Transform subBallsContainer = transform.Find("SubBalls");
        switch (bolt.name)
        {
            case "IceBall":
                {
                    SpawnBullet(bolt, subBallsContainer, "IceBallContainer");
                    break;
                }
            default: break;
        }
    }

    private void SpawnBullet(Transform bolt, Transform subBallsContainer, string ballContainerName)
    {
        if (ballContainerName == "" || !bolt) return;
        Transform ballContainer = subBallsContainer.Find(ballContainerName);
        if (!ballContainer) return;
        Transform subBullet = Instantiate(bolt, ballContainer);
        subBullet.GetComponent<SubBulletRotation>().target = transform;
    }
}
