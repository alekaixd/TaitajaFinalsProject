using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering.LookDev;
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

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
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
