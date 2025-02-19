using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBuff : Buff
{
    public SampleBuff()
    {
        name = "Sample Buff";
        description = "Sample Buff Description";
    }

    public override void OnSubmit()
    {
        Debug.Log("Sample Buff On Submit");
    }

    public override void OnReject()
    {
        Debug.Log("Sample Buff On Reject");
    }

    public override void OnThird()
    {
        Debug.Log("Sample Buff On Third");
    }

    public override void OnCorrect()
    {
        Debug.Log("Sample Buff On Correct");
    }

    public override void OnIncorrect()
    {
        Debug.Log("Sample Buff On Incorrect");
    }

    public override void OnAny()
    {
        Debug.Log("Sample Buff On Any");
    }
}
