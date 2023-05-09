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
    public TMP_Text CoinText;
    public int coins = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CoinText.text = "Coins " + coins.ToString();
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
        CoinText.text = "Coins " + coins.ToString();

    }
}
