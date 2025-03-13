using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using static UnityEngine.Rendering.DebugUI;

public class HealthManager : MonoBehaviour
{
    public static int health = 10;

    [SerializeField]
    private int maxHealth = 50;

    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private GameObject squaresOrigin;
    private List<GameObject> squares = new List<GameObject>();

    [SerializeField]
    private GameObject squarePrefab;

    [SerializeField]
    private Transform squareSpacing;

    private Vector3 initialHealthSize;

    //singleton
    [HideInInspector]
    public static HealthManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        SetHealth(health);
        UpdateHealthDisplay();
        initialHealthSize = text.gameObject.transform.localScale;
    }

    public void ChangeHealth(int value)
    {
        health = Mathf.Clamp(health + value, 0, maxHealth);
    }

    public void SetHealth(int value)
    {
        health = Mathf.Clamp(value, 0, maxHealth);
    }

    public void UpdateHealthDisplay()
    {
        UpdateText();

        if (health > squares.Count)
        {
            for (int _ = squares.Count; _ < health; _++) AddSquare();
        }
        else if (health < squares.Count)
        {
            for (int _ = squares.Count; _ > health; _--) RemoveSquare();
        }
    }

    private void UpdateText()
    {
        if (text.text != health.ToString())
        {
            text.text = health.ToString();
            StartCoroutine(UpdateTextCoroutine());
        }
    }

    private IEnumerator UpdateTextCoroutine()
    {
        float totalTime = 0.30f;
        float time = Time.time;
        while (Time.time - time < totalTime)
        {
            float progress = (Time.time - time) / totalTime;
            text.gameObject.transform.localScale = Vector3.Lerp(initialHealthSize * 0.75f, initialHealthSize, 1f - Mathf.Pow((1f - progress), 2));
            yield return null;
        }
    }

    private void AddSquare()
    {
        int index = squares.Count + 1;
        Vector3 position = squaresOrigin.transform.position;
        position.x += ((index - 1) % 10) * (squareSpacing.position.x - squaresOrigin.transform.position.x);
        position.y += ((index - 1) / 10) * (squareSpacing.position.y - squaresOrigin.transform.position.y);
        GameObject square = Instantiate(squarePrefab, squaresOrigin.transform);
        square.transform.position = position;
        square.transform.SetParent(squaresOrigin.transform);
        squares.Add(square);
    }

    private void RemoveSquare()
    {
        // Remove the last square
        GameObject square = squares[squares.Count - 1];
        squares.Remove(square);
        Destroy(square);
    }
}
