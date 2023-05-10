using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

/*
 * collects the coin and moves the collected coin out of view
 * moves the coin back after some time
 */

public class CoinScript : MonoBehaviour
{
    

    private GameManager gameManager;

    public float coinRespawnTime = 7.0f;


    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Debug.Log(gameManager);
    }


    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision) //checks for the player and adds the coins
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("playerFound");
            gameManager.increaseCoins(gameManager.coinValue);
            Debug.Log("increase coins");
            StartCoroutine(CoinRespawnTimer(coinRespawnTime));
        }
    }

    private IEnumerator CoinRespawnTimer(float respawnTime)// teleports the coin out of view and back after some time
    {
        Debug.Log("coroutineStarted");
        Vector2 originalPosition = transform.position;
        gameObject.transform.Translate(100, 100, 0); //magic numbers teleport the coin out of view
        yield return new WaitForSeconds(respawnTime);
        gameObject.transform.position = originalPosition;
    }
}
