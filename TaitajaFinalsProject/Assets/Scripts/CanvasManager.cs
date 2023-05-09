using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CanvasManager : MonoBehaviour
{

    public GameObject[] levels;
    
    public GameObject arrowRight;
    public GameObject arrowLeft;
    public int selectedLevel = 0;

    private CameraController cameraController;



    // Start is called before the first frame update
    void Start()
    {
        cameraController = GameObject.Find("CameraController").GetComponent<CameraController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToDirection(int level)
    {
        cameraController.MoveCamera(levels[level], level);
    }

   

    private void OnMouseDown()
    {
        if(gameObject == arrowRight)
        {
            Debug.Log("moveRight");
        }
    }
}
