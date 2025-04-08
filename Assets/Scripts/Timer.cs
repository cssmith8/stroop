using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private GameObject circle, bar, countdown;

    public float timeMax = 10f;
    public float timeRemaining = 10f;

    public void BeginTimer(float time)
    {
        timeMax = time;
        timeRemaining = timeMax;
        StartCoroutine(TimerTicking());
    }

    IEnumerator TimerTicking()
    {
        while (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateProgressBar();
            yield return null;
        }
        GameManager.instance.OnTimerExpire();
    }

    private void UpdateProgressBar()
    {
        float timeFraction = Mathf.Clamp01(timeRemaining / timeMax);
        bar.transform.localScale = new Vector3(Mathf.Clamp01(timeFraction - 0.05f), 1, 1);

        countdown.GetComponent<TMP_Text>().text = GetCountdownTime(timeRemaining);

        if (timeFraction > 0.5f) return;

        float doubleTime = timeFraction * 2;
        float doubleTimeInverse = 1f - doubleTime;

        circle.transform.localScale = new Vector3(Mathf.Pow(doubleTime, 2) * 2f, Mathf.Pow(doubleTime, 2) * 2f, 1);
        circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, Mathf.Pow(doubleTimeInverse, 5));
    }

    private string GetCountdownTime(float time) {
        //return a string with 1 decimal place, including a 0 if the number is less than 10
        //also include a ".0" if the number is a whole number
        float real = Mathf.CeilToInt(time * 10) / 10f;
        if (real % 1f == 0f) {
            return real.ToString() + ".0";
        }
        return real.ToString();
    }

    public float GetFractionTimeRemaining()
    {
        return timeRemaining / timeMax;
    }
}
