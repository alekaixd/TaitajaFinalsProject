using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * used to load the level scenes
 */

public class LevelSelectorScript : MonoBehaviour
{
    public CanvasManager canvasManager;

    void OnMouseDown() // checks for tags and loads the specified level
    {
        if (gameObject.CompareTag("Level1"))
        {
            SceneManager.LoadScene("Level 1");
            Debug.Log("Level1");
        }
        else if (gameObject.CompareTag("Level2") && canvasManager.unlockedLevels >= 1)
        {
            Debug.Log("Level2");
        }
        else if (gameObject.CompareTag("Level3") && canvasManager.unlockedLevels >= 2)
        {
            Debug.Log("Level3");
        }
    }
}
