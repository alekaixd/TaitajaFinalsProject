using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public int time;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Timer()
    {
        timerText.text = "Time: " + time.ToString();
        yield return new WaitForSeconds(1);
        time -= 1;
        if(time <= 0)
        {
            SceneManager.LoadScene("SampleScene");
        }

        StartCoroutine(Timer());
    }
}
