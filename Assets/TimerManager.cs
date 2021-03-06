using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;

    public TextMeshProUGUI timerTxt,bestTimeTxt;
    
    TimeSpan currentTime, bestTime, previousTime;

    public bool timerGoing;
    private float elapsedTime;

    private void Awake()
    {
        instance = this;

        if (instance != this)
            Destroy(this);
    }

    private void Start()
    {
        timerGoing = false;

        timerTxt.enabled = false;

        bestTime = TimeSpan.MaxValue;
    }

    public void BeginTimer()
    {
        timerGoing = true;

        timerTxt.enabled = true;

        elapsedTime = 0;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;

        StartCoroutine(HideTimerTxt());
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;

            currentTime = TimeSpan.FromSeconds(elapsedTime);

            string timeStr = currentTime.ToString("mm':'ss'.'ff");

            timerTxt.text = timeStr;

            yield return null;
        }
    }

    private IEnumerator HideTimerTxt()
    {
        yield return new WaitForSeconds(8f);

        timerTxt.enabled = false;
    }

    public void FinishTimer()
    {
        EndTimer();

        previousTime = currentTime;

        if(bestTime == null || previousTime < bestTime)
        {
            bestTime = previousTime;

            string bestTimeStr = "Best Time: " + bestTime.ToString("mm':'ss'.'ff");

            bestTimeTxt.text = bestTimeStr;
        }
    }

    public void CancelTimer()
    {
        EndTimer();
    }
}
