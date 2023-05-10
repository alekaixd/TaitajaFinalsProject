using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * doesn't destroy assigned object
 */
public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        

        
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
