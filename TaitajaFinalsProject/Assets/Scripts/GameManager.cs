using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public TMP_Text CoinText;
    public int coins = 0;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        CoinText.text = "Coins " + coins.ToString();
    }

    // Update is called once per frame
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
