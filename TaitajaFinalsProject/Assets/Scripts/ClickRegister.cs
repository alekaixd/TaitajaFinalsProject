using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ClickRegister : MonoBehaviour
{
    private CanvasManager canvasManager;

    // Start is called before the first frame update
    void Start()
    {
        canvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveRight() 
    {
        if(canvasManager.selectedLevel != canvasManager.levels.Length - 1) // magic number becouse levels index starts at 0 and selected level at 1
        {
            canvasManager.selectedLevel += 1;
            canvasManager.MoveToDirection(canvasManager.selectedLevel);
        }
    }
    public void MoveLeft()
    {
        if (canvasManager.selectedLevel > 0)
        {
            canvasManager.selectedLevel -= 1;
            canvasManager.MoveToDirection(canvasManager.selectedLevel);
        }
    }
}
