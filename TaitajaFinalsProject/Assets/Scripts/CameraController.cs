using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Controls the camera movement when swiching between levels and at the start
 * zooms the camera in at the start
 */

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera zoomCamera; // used to get a transform and a size to move the main camera
    public float speed = 5.0f;
    public float zoomSpeed = 5.0f;
    public bool startZoom = false; //starts the zooming effect
    public GameObject arrows; // used to disable menu movement arrows

    private Vector3 originalCameraPosition;
    private float originalZoomSize; // float where the zoom ends
    private float zoomSize; //  zoom float where the zoom starts
    private CanvasManager canvasManager;
    private float beforeZoomTime = 1.0f; // delay float
    private bool switchLevel = false;
    private int currentLevel = 0;

    
    void Start() // sets the camera at correct position and size and saves original position data
    {
        originalCameraPosition = mainCamera.transform.position;

        originalZoomSize = mainCamera.GetComponent<Camera>().orthographicSize;
        zoomSize = zoomCamera.GetComponent<Camera>().orthographicSize;

        mainCamera.transform.Translate(new Vector2(zoomCamera.transform.position.x, zoomCamera.transform.position.y));
        mainCamera.GetComponent<Camera>().orthographicSize = zoomSize;

        canvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>();

        arrows.SetActive(false);

        StartCoroutine(StartZoom(beforeZoomTime)); // coroutine waits a bit before activating zoom effect
    }

    
    void Update()
    {
        if(startZoom == true) //zooms and moves the camera towards original position of the camera
        {
            float step = speed * Time.deltaTime; // how much the camera moves towards the original position

            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(originalCameraPosition.x, originalCameraPosition.y, originalCameraPosition.z), step);

            if(originalZoomSize <= mainCamera.GetComponent<Camera>().orthographicSize) // does the zooming when current size is bigger than the original
            {
                mainCamera.GetComponent<Camera>().orthographicSize -= zoomSpeed * Time.deltaTime;

                if(mainCamera.GetComponent<Camera>().orthographicSize < originalZoomSize) //corrects the positioning for when the zoom wants to be stopped
                {
                    mainCamera.GetComponent<Camera>().orthographicSize = originalZoomSize;
                }
            }
            
            if(mainCamera.GetComponent<Camera>().orthographicSize == originalZoomSize ) //stops the zoom
            {
                startZoom = false;
                arrows.gameObject.SetActive(true);
            }

        }

        if(switchLevel == true) //after the initial zoom is done this calls for an update in the camera
        {
            MoveCamera(canvasManager.levels[currentLevel], currentLevel);
        }
    }
    private IEnumerator StartZoom(float timeBeforeZoom) // beginning delay for zoom start
    {
        yield return new WaitForSeconds(timeBeforeZoom);
        startZoom = true;
    }

    public void MoveCamera(GameObject nextLevel, int level)// moves the camera towards "next level" or selected level
    {
        switchLevel = true;
        currentLevel = level;
        float step = 2 * speed * Time.deltaTime;

        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(nextLevel.transform.position.x, nextLevel.transform.position.y, mainCamera.transform.position.z), step);
    }
}
