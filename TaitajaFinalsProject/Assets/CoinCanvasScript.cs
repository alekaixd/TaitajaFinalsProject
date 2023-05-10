using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinCanvasScript : MonoBehaviour
{

    public TMP_Text coinText;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        coinText.text = "Coins " + gameManager.coins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score)
    {
        coinText.text = "Coins " + score.ToString();
    }
}
