using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/*
 * used to register "map scene" arrow clicks
 */

public class ClickRegister : MonoBehaviour
{
    private CanvasManager canvasManager;

    void Start()
    {
        canvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>();
    }

    public void MoveRight() //changes the level to the one on the right
    {
        if(canvasManager.selectedLevel != canvasManager.levels.Length - 1) // magic number becouse levels index starts at 0 and selected level at 1
        {
            canvasManager.selectedLevel += 1;
            canvasManager.MoveToDirection(canvasManager.selectedLevel);
            AudioManager.instance.PlaySFX("liiku");
        }
    }
    public void MoveLeft() // changes the level to the one on the left
    {
        if (canvasManager.selectedLevel > 0) // makes sure that doesn't select a level that does not exist
        {
            canvasManager.selectedLevel -= 1;
            canvasManager.MoveToDirection(canvasManager.selectedLevel);
            AudioManager.instance.PlaySFX("liiku");
        }
    }
}
