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
        timeLeft = 15;
        timeCountOn = true;
        StartCoroutine(Countdown());
    }

    void Update()
    {
        timeBar.GetComponent<RectTransform>().DOScaleX(timeLeft, 1f).SetEase(Ease.Linear);
    }

    IEnumerator Countdown()
    {
        while (timeCountOn)
        {
            timeLeft--;
            yield return new WaitForSeconds(1f);
            if (timeLeft <= 0)
            {
                timeLeft = 0;
                Debug.Log("FINISHED");
                timeCountOn = false;
                timeBar.SetActive(false);
            }
        }
    }
}
