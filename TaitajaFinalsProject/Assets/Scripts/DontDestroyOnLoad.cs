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
}
