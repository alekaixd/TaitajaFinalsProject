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

    public GameObject[] lockIcons;
    public GameObject[] levelText;


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
        if (gameManager.coins >= 20)
        {
            Debug.Log("Osta duoble jump");
            Debug.Log(gameManager.doubleJumpActive);
            doubleJump.SetActive(false);
            AudioManager.instance.PlaySFX("Buying SoundEffect");
            gameManager.doubleJumpActive = true;
            Debug.Log(gameManager.doubleJumpActive);
        }
    }

    public void buyDoubleCoins()
    {
        if (gameManager.coins >= 20)
        {
            gameManager.coins -= 20;
            doubleCoins.SetActive(false);
            gameManager.coinValue = 2;
            AudioManager.instance.PlaySFX("Buying SoundEffect");
        }

    }

    public void buyNextLevel() // unlocks a new level to be entered 
    {
        if (gameManager.coins >= 50)
        {
            gameManager.coins -= 50;
            gameManager.unlockedLevels += 1;
            lockIcons[gameManager.unlockedLevels - 1].SetActive(false);
            levelText[gameManager.unlockedLevels - 1].SetActive(true);

            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlaySFX("Buying SoundEffect");
            }

            if (gameManager.unlockedLevels == 2)
            {
                nextLevel.SetActive(false);
            }
        }
    }


}
