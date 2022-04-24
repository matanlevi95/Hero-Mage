using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;
    [HideInInspector] public int coinsAmount = 0;
    Transform target;
    PlayerExperience playerExperience;
    [HideInInspector] public bool move;

    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (!playerObject) return;
        target = playerObject.transform;
        playerExperience = playerObject.GetComponent<PlayerExperience>();
    }
    void Update()
    {
        if (move) Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && move)
        {
            playerExperience.GainExperienceFlatRate(coinsAmount);
            Destroy(gameObject);
        }
    }
}
