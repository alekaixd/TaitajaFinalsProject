using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*
 * manages the collected coins in the levels and the coin text
 */

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public CoinCanvasScript coinCanvasScript;
    
    public int coins = 0;
    public int coinValue = 1;

    public int unlockedLevels = 0;


    public bool doubleJumpActive = false;

    private CanvasManager canvasManager;



    private void Awake()
    {
        Instance = this;
        canvasManager = GameObject.Find("Canvas").GetComponent<CanvasManager>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        doubleJumpActive = canvasManager.onkotuplahyppyOstettu;
    }

    public enum GameState
    {

    }

    public void increaseCoins(int coinsToAdd)
    {
        coins += coinsToAdd;
        coinCanvasScript = GameObject.Find("CoinCanvas").GetComponent<CoinCanvasScript>();
        coinCanvasScript.UpdateScore(coins);

    }
}
