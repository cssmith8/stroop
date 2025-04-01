using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enum for upgrades
public enum Upgrade
{
    RED,
    GREEN,
    BLUE,
    CHROMA
}

public class Buff
{
    public string name = "Buff";

    public virtual string GetDescription()
    {
        return "Buff description";
    }

    public List<Upgrade> upgrades = new List<Upgrade>();

    private BuffDisplay display;

    public static string RedWord(string word)
    {
        return "<color=#ff0000>" + word + "</color>";
    }

    public static string GreenWord(string word)
    {
        return "<color=#00ff00>" + word + "</color>";
    }

    public static string BlueWord(string word)
    {
        return "<color=#0000ff>" + word + "</color>";
    }

    protected void PlayAnimation()
    {
        if (display) display.PlayAnimation();
    }

    protected int NumUpgrades(Upgrade type)
    {
        int count = 0;
        foreach (Upgrade upgrade in upgrades)
        {
            if (upgrade == type || upgrade == Upgrade.CHROMA)
            {
                count++;
            }
        }
        return count;
    }

    public bool AddUpgrade(Upgrade type)
    {
        if (upgrades.Count < 3)
        {
            upgrades.Add(type);
            return true;
        }
        return false;
    }

    public int TotalUpgrades()
    {
        return upgrades.Count;
    }

    public virtual void OnSubmit() { }
    public virtual void OnReject() { }
    public virtual void OnThird() { }
    public virtual void OnCorrect() { }
    public virtual void OnIncorrect() { }
    public virtual void OnAny() { }
    public virtual void OnCorrectSubmission() { }
    public virtual void OnIncorrectSubmission() { }
    public virtual void OnCorrectRejection() { }
    public virtual void OnIncorrectRejection() { }
}