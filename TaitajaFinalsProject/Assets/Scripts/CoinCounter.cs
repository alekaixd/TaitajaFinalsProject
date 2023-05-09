using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public static CoinCounter Instance;

    public TMP_Text CoinText;

    public int CurrentCoins = 0;


    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

        CoinText.text = "Coins " + CurrentCoins.ToString();
    }

    public void increaseCoins (int v)
    {
        CurrentCoins += v;
        CoinText.text = "Coins " + CurrentCoins.ToString();

    }
}
