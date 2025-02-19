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

    public virtual void OnSubmit()
    {
        Debug.Log("Buff On Submit");
    }

    public virtual void OnReject()
    {
        Debug.Log("Buff On Reject");
    }

    public virtual void OnThird()
    {
        Debug.Log("Buff On Third");
    }

    public virtual void OnCorrect()
    {
        Debug.Log("Buff On Correct");
    }

    public virtual void OnIncorrect()
    {
        Debug.Log("Buff On Incorrect");
    }

    public virtual void OnAny()
    {
        Debug.Log("Buff On Any");
    }

    public virtual void OnCorrectSubmission()
    {
        Debug.Log("Buff On Correct Submission");
    }

    public virtual void OnIncorrectSubmission()
    {
        Debug.Log("Buff On Incorrect Submission");
    }

    public virtual void OnCorrectRejection()
    {
        Debug.Log("Buff On Correct Rejection");
    }

    public virtual void OnIncorrectRejection()
    {
        Debug.Log("Buff On Incorrect Rejection");
    }
}