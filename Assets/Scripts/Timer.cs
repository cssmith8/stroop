using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    [SerializeField]
    private GameObject circle, bar;

    public float timeMax, timeRemaining;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        timeMax = 10f;
        timeRemaining = timeMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateProgressBar();
        }
        else
        {
            timeRemaining = 0;
        }
    }

    private void UpdateProgressBar()
    {
        float timeFraction = Mathf.Clamp01(timeRemaining / timeMax);
        bar.transform.localScale = new Vector3(timeFraction, 1, 1);

        if (timeFraction > 0.5f) return;

        float doubleTime = timeFraction * 2;
        float doubleTimeInverse = 1f - doubleTime;

        circle.transform.localScale = new Vector3(doubleTime, doubleTime, 1);
        circle.GetComponent<Image>().color = new Color(1f, 1f, 1f, Mathf.Pow(doubleTimeInverse, 5));
    }

    public float GetFractionTimeRemaining()
    {
        return timeRemaining / timeMax;
    }
}
