using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private GameObject circle, bar;

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

        if (timeFraction > 0.5f) return;

        float doubleTime = timeFraction * 2;
        float doubleTimeInverse = 1f - doubleTime;

        circle.transform.localScale = new Vector3(Mathf.Pow(doubleTime, 2) * 2f, Mathf.Pow(doubleTime, 2) * 2f, 1);
        circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, Mathf.Pow(doubleTimeInverse, 5));
    }

    public float GetFractionTimeRemaining()
    {
        return timeRemaining / timeMax;
    }
}
