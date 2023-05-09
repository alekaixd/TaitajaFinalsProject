using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using Debug = UnityEngine.Debug;


public class CoinScript : MonoBehaviour
{
    public int value;

    public GameManager gameManager;

    public float coinRespawnTime = 7.0f;

    //public GameObject CoinPrefab;

    private void Start()
    {

    }
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameManager.increaseCoins(value);
            StartCoroutine(CoinRespawnTimer(coinRespawnTime));
        }
    }

    private IEnumerator CoinRespawnTimer(float respawnTime)
    {
        Vector2 originalPosition = transform.position;
        gameObject.transform.Translate(100, 100, 0); //magic numbers teleport the coin out of view
        yield return new WaitForSeconds(respawnTime);
        gameObject.transform.position = originalPosition;
    }
}
