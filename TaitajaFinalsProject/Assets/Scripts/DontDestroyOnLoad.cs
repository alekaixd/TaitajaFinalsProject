using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * doesn't destroy assigned object
 */
public class DontDestroyOnLoad : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);

        
    }

    private void Update()
    {
        if (gameObject.CompareTag("CoinCanvas"))
        {
            gameObject.GetComponent<Canvas>().worldCamera = Camera.main;
            gameObject.GetComponent<Canvas>().planeDistance = 10;
        }
    }
}
