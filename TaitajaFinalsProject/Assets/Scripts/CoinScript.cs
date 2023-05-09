using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;
using Debug = UnityEngine.Debug;


public class CoinScript : MonoBehaviour
{
    public int value;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(gameObject);
            CoinCounter.Instance.increaseCoins(value);



        }
    }
}
