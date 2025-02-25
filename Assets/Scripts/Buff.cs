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
    public string description = "Buff Description";

    public List<Upgrade> upgrades = new List<Upgrade>();

    private BuffDisplay display;

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