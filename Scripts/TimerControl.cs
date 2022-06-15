using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerControl : MonoBehaviour
{

    [SerializeField] float startTime = 5f;
    [SerializeField] TextMeshPro timertxt;

    float timer = 0f;

    void Start()
    {
        StartCoroutine(TimerCounter());
    }

    private IEnumerator TimerCounter()
    {
        timer = startTime;

        do
        {
            timer -= Time.deltaTime;

            FormatText();

            yield return null;
        }
        while (timer > 0);
        SceneManager.LoadScene("GameOver");
    }

    private void FormatText()
    {
        int min = (int)(timer/60) % 60;
        int sec = (int)(timer % 60);

        timertxt.text = " ";
        
        if (min >= 10)
        {
            timertxt.text += min + ":";
        }
        else
        {
            timertxt.text += "0" +min + ":";
        }
        
        
        if (sec >= 10)
        {
            timertxt.text += sec;
        }
        else
        {
            timertxt.text += "0" + sec;
        }
        
    }
    public void EndGame(){
        StopAllCoroutines();
    }

}
