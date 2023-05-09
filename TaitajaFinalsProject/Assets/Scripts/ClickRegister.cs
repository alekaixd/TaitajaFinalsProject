using System.Collections;
using System.Collections.Generic;
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

    private void OnMouseDown()
    {
        Debug.Log("Click!");

        if (gameObject.CompareTag("ArrowRight"))
        {
            Debug.Log("CLICK!");
            canvasManager.selectedLevel += 1;
            canvasManager.MoveToDirection(canvasManager.selectedLevel);
        }

        else if (gameObject.CompareTag("ArrowLeft"))
        {
            canvasManager.selectedLevel -= 1;
            canvasManager.MoveToDirection(canvasManager.selectedLevel);
        }
    }

    public void MoveRight() 
    {
        Debug.Log("CLICK!");
        canvasManager.selectedLevel += 1;
        canvasManager.MoveToDirection(canvasManager.selectedLevel);
    }
    public void MoveLeft()
    {
        canvasManager.selectedLevel -= 1;
        canvasManager.MoveToDirection(canvasManager.selectedLevel);
    }
}
