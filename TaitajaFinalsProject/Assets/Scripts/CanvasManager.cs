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
    public GameObject doubleJump;
    public GameObject doubleCoins;
    public GameObject nextLevel;
    public GameObject shopIcon;
    public GameObject shopOverlay;
    public int selectedLevel = 0;
    public int unlockedLevels = 0;

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

    public void buyNextLevel()
    {
        nextLevel.SetActive(false);
        unlockedLevels += 1;
        AudioManager.instance.PlaySFX("Buying SoundEffect");
    }
}
