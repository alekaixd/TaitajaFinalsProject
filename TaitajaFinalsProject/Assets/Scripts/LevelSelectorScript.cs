using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("Level1"))
        {
            SceneManager.LoadScene("Level 1");
            Debug.Log("Level1");
        }
        else if (gameObject.CompareTag("Level2"))
        {
            Debug.Log("Level2");
        }
        else if (gameObject.CompareTag("Level3"))
        {
            Debug.Log("Level3");
        }
    }
}
