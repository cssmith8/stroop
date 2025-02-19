using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff
{
    public string name = "Buff";
    public string description = "Buff Description";

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
}