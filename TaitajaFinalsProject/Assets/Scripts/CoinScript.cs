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

    public Vector2 SpawnLocation;
    public Vector2 teleportLocation;

    public float TimeLeft;
    public bool TimerOn = false;

    //public GameObject CoinPrefab;

    private void Start()
    {
        SpawnLocation = transform.position;
        Debug.Log(SpawnLocation);
    }
    void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Aika");
                TimeLeft = 0;
                TimerOn = false;

                transform.position = SpawnLocation;
                //Instantiate (CoinPrefab, SpawnLocation, Quaternion.identity);
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log(teleportLocation);
            transform.position = teleportLocation;

            //Destroy(gameObject);

            TimerOn = true;
            CoinCounter.Instance.increaseCoins(value);

        }
    }
}
