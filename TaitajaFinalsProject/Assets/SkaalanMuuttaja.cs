using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkaalanMuuttaja : MonoBehaviour
{
    public float speed = 5f;
    Vector2 temp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        temp = transform.localScale * Time.deltaTime;

        temp.x -= 1f;

        transform.localScale = temp;    
        
    }
}
