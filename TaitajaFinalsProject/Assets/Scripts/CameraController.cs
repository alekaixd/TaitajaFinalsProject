using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera zoomCamera; // used to get a transform and a size to move the main camera
    public float speed = 5.0f;
    public float zoomSpeed = 3.0f;
    public bool startZoom = false;
    public GameObject arrows;

    private Vector3 originalCameraPosition;
    private float originalZoomSize;
    private float zoomSize;
    private CanvasManager canvasManager;
    private float beforeZoomTime = 1.0f;
    private bool switchLevel = false;
    private int currentLevel = 0;

    
    void Start()
    {
        originalCameraPosition = mainCamera.transform.position;

        originalZoomSize = mainCamera.GetComponent<Camera>().orthographicSize;
        zoomSize = zoomCamera.GetComponent<Camera>().orthographicSize;

        mainCamera.transform.Translate(new Vector2(zoomCamera.transform.position.x, zoomCamera.transform.position.y));
        mainCamera.GetComponent<Camera>().orthographicSize = zoomSize;

        canvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>();

        arrows.SetActive(false);

        StartCoroutine(StartZoom(beforeZoomTime));
    }

    
    void Update()
    {
        if(startZoom == true)
        {
            float step = speed * Time.deltaTime;

            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(originalCameraPosition.x, originalCameraPosition.y, originalCameraPosition.z), step);

            if(originalZoomSize <= mainCamera.GetComponent<Camera>().orthographicSize)
            {
                mainCamera.GetComponent<Camera>().orthographicSize -= 5.0f * Time.deltaTime;

                if(mainCamera.GetComponent<Camera>().orthographicSize < originalZoomSize)
                {
                    mainCamera.GetComponent<Camera>().orthographicSize = originalZoomSize;
                }
            }
            
            if(mainCamera.GetComponent<Camera>().orthographicSize == originalZoomSize )
            {
                startZoom = false;
                arrows.gameObject.SetActive(true);
            }

        }

        if(switchLevel == true) 
        {
            MoveCamera(canvasManager.levels[currentLevel], currentLevel);
        }
    }
    private IEnumerator StartZoom(float timeBeforeZoom)
    {
        yield return new WaitForSeconds(timeBeforeZoom);
        startZoom = true;
    }

    public void MoveCamera(GameObject nextLevel, int level)
    {
        switchLevel = true;
        currentLevel = level;
        float step = 2 * speed * Time.deltaTime;

        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(nextLevel.transform.position.x, nextLevel.transform.position.y, mainCamera.transform.position.z), step);
    }
}
