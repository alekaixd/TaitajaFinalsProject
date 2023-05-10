using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowerHorizonta : MonoBehaviour
{
    public GameObject Player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Player.transform.position.x, 0, gameObject.transform.position.z);
    }
}
