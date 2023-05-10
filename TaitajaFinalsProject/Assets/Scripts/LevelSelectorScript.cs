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
    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnMouseDown() // checks for tags and loads the specified level
    {
        if(canvasManager.shopOverlay.activeSelf == false)
        {
            if (gameObject.CompareTag("Level1") && canvasManager.selectedLevel == 0)
            {
                SceneManager.LoadScene("Level 1");
            }
            else if (gameObject.CompareTag("Level2") && gameManager.unlockedLevels >= 1 && canvasManager.selectedLevel == 1)
            {
                SceneManager.LoadScene("Level 2");
            }
            else if (gameObject.CompareTag("Level3") && gameManager.unlockedLevels >= 2 && canvasManager.selectedLevel == 2)
            {
                SceneManager.LoadScene("Level 3");
            }
        }
    }
}
