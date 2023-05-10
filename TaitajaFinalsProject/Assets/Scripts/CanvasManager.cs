using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
 * script manages all activity on the "map scene" canvas
 */

public class CanvasManager : MonoBehaviour
{

    public GameObject[] levels; // all clickable level objects
    
    public GameObject doubleJump;
    public GameObject doubleCoins;
    public GameObject nextLevel;
    public GameObject shopIcon;
    public GameObject shopOverlay;

    public GameManager gameManager;

    public int selectedLevel = 0; // used in the click register

    private CameraController cameraController;

    void Start()
    {
        cameraController = GameObject.Find("CameraController").GetComponent<CameraController>();
    }

    public void MoveToDirection(int level) // starts moving the camera towards the next level when called
    {
        cameraController.MoveCamera(levels[level], level); // "levels[level]" is the level the camera is going to stop at and integer level is used in the camera controller
    }

    public void ActivateShopOverlay()
    {
        if (shopOverlay.activeSelf == true) 
        {
            shopOverlay.SetActive(false);
        }
        else 
        { 
            shopOverlay.SetActive(true);
            AudioManager.instance.PlaySFX("Kauppa Click");
        }
        
    }

    public void buyDoubleJump()
    {
        doubleJump.SetActive(false);
        AudioManager.instance.PlaySFX("Buying SoundEffect");
        
    }

    public void buyDoubleCoins()
    {
        doubleCoins.SetActive(false);
        AudioManager.instance.PlaySFX("Buying SoundEffect");
    }

    public void buyNextLevel() // unlocks a new level to be entered 
    {
        //nextLevel.SetActive(false);
        gameManager.unlockedLevels += 1;
        AudioManager.instance.PlaySFX("Buying SoundEffect");
    }


}
