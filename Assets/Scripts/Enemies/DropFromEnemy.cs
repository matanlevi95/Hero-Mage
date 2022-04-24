using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropFromEnemy : MonoBehaviour
{
    [SerializeField] int minCoins = 20;
    [SerializeField] int maxCoins = 50;
    Transform coinsContainer;
    GameManager gameManager;

    private void Start()
    {
        coinsContainer = GameObject.FindGameObjectWithTag("CoinsContainer").transform;
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManagerObject) gameManager = gameManagerObject.GetComponent<GameManager>();
    }

    public void DropLoot()
    {
        int randomCoinAmount = Random.Range(minCoins, maxCoins);
        Transform coinPrefab = GetCoinTypeByAmount(randomCoinAmount);
        if (!coinPrefab) return;
        Transform newCoin = Instantiate(coinPrefab, new Vector3(transform.position.x, 2.5f, transform.position.z), Quaternion.identity, coinsContainer);
        newCoin.GetComponent<Coin>().coinsAmount = randomCoinAmount;
    }

    Transform GetCoinTypeByAmount(int randomCoinAmount)
    {
        Transform relevantCoinToSpawn = null;
        foreach (var coinType in gameManager.coinsTypes)
        {
            if (coinType.min <= randomCoinAmount && coinType.max >= randomCoinAmount)
            {
                relevantCoinToSpawn = coinType.coinPrefab;
            }
        }
        return relevantCoinToSpawn;
    }

}
