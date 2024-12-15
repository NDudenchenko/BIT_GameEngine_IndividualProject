using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public TimerCollider StartCollider;
    public TimerCollider FinishCollider;
    public TextMeshProUGUI TimerText;

    private float secondsCount;
    private int minuteCount;
    private bool isCounterWorks = false;

    void Start()
    {
        StartCollider.CollideWithPlayer += () => OnStartColliderTriggered();
        FinishCollider.CollideWithPlayer += () => OnFinishColliderTriggered();
    }

    void Update()
    {
        if (isCounterWorks)
        {
            secondsCount += Time.deltaTime;
            if (secondsCount >= 60)
            {
                minuteCount++;
                secondsCount = 0;
            }

            //Debug.Log(minuteCount + "m:" + (int)secondsCount + "s");

            TimerText.text = minuteCount + "m:" + (int)secondsCount + "s";
        }
        else
        {
            secondsCount = 0;
            minuteCount = 0;
        }
    }

    public void OnStartColliderTriggered()
    {
        isCounterWorks = true;
    }

    public void OnFinishColliderTriggered()
    {
        isCounterWorks = false;

        //Finish points score !
    }
}
