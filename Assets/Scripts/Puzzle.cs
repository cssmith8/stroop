using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum PuzzleColor
{
    RED,
    BLUE,
    GREEN,
    YELLOW,
    PURPLE,
    CYAN,
    WHITE,
}

public class Puzzle : MonoBehaviour
{
    public bool solution = false;
    private string text = "RED";
    private PuzzleColor color = PuzzleColor.RED;

    private TMP_Text textComponent;

    public static string GetColorString(PuzzleColor color)
    {
        switch (color)
        {
            case PuzzleColor.RED:
                return "RED";
            case PuzzleColor.BLUE:
                return "BLUE";
            case PuzzleColor.GREEN:
                return "GREEN";
            case PuzzleColor.YELLOW:
                return "YELLOW";
            case PuzzleColor.PURPLE:
                return "PURPLE";
            case PuzzleColor.CYAN:
                return "CYAN";
            case PuzzleColor.WHITE:
                return "WHITE";
            default:
                return "RED";
        }
    }

    //set text
    public void SetText(string text)
    {
        this.text = text;
        textComponent.text = text;
    }

    //get text
    public string GetText()
    {
        return text;
    }

    //set color
    public void SetColor(PuzzleColor color)
    {
        this.color = color;
        switch (color)
        {
            case PuzzleColor.RED:
                textComponent.color = Color.red;
                break;
            case PuzzleColor.BLUE:
                textComponent.color = Color.blue;
                break;
            case PuzzleColor.GREEN:
                textComponent.color = Color.green;
                break;
            case PuzzleColor.YELLOW:
                textComponent.color = Color.yellow;
                break;
        }
    }

    //get color
    public PuzzleColor GetColor()
    {
        return color;
    }

    void Awake()
    {
        textComponent = transform.GetChild(0).GetComponent<TMP_Text>();
        SetColor(color);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
