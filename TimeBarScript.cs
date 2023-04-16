using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TimeBarScript : MonoBehaviour
{
    public GameObject timeBar;
    public bool timeCountOn;
    public float timeLeft;

    void Start()
    {
        timeLeft = 15; //how many seconds would you like to countdown
        timeCountOn = true; //countdown can start
        StartCoroutine(Countdown()); //start the countdown
    }

    void Update()
    {
        timeBar.GetComponent<RectTransform>().DOScaleX(timeLeft, 1f).SetEase(Ease.Linear); //time bar smoothly run out
    }

    IEnumerator Countdown() //reducing time 
    {
        while (timeCountOn) //if countdown can start
        {
            timeLeft--; //decrease by one second
            yield return new WaitForSeconds(1f); //wait for an actual one second
            if (timeLeft <= 0) //if time runs out
            {
                timeLeft = 0;
                Debug.Log("FINISHED");
                timeCountOn = false; 
                timeBar.SetActive(false); //just to make sure time bar is invisible
                //do something
                //for more info, watch the video in readme file
            }
        }
    }
}
