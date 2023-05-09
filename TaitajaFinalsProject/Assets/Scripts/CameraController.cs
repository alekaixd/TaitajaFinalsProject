using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera mainCamera;
    public Camera zoomCamera; // used to get a transform and a size to move the main camera
    public float speed = 5.0f;
    public float zoomSpeed = 3.0f;

    private Vector3 originalCameraPosition;
    private float originalZoomSize;
    private float zoomSize;
    private bool startZoom = false;

    
    void Start()
    {
        originalCameraPosition = mainCamera.transform.position;
        originalZoomSize = mainCamera.GetComponent<Camera>().orthographicSize;
        zoomSize = zoomCamera.GetComponent<Camera>().orthographicSize;
        mainCamera.transform.Translate(new Vector2(zoomCamera.transform.position.x, zoomCamera.transform.position.y));
        mainCamera.GetComponent<Camera>().orthographicSize = zoomSize;
    }

    
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            startZoom = true;
        }

        if(startZoom == true)
        {
            float step = speed * Time.deltaTime;

            mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, new Vector3(originalCameraPosition.x, originalCameraPosition.y, originalCameraPosition.z), step);

            if(originalZoomSize < mainCamera.GetComponent<Camera>().orthographicSize)
            {
                mainCamera.GetComponent<Camera>().orthographicSize -= 5.0f * Time.deltaTime;
            }
            
        }
    }
}
