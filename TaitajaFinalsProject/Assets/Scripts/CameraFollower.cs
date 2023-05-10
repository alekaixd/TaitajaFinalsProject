using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(0, Player.transform.position.y, gameObject.transform.position.z);
    }
}
