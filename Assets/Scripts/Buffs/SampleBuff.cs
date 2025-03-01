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
        //Debug.Log("Sample Buff On Submit");
        int value = NumUpgrades(Upgrade.RED);
        HealthManager.instance.ChangeHealth(1 + value);
    }

    public override void OnReject()
    {
        //Debug.Log("Sample Buff On Reject");
    }

    public override void OnThird()
    {
        //Debug.Log("Sample Buff On Third");
    }

    public override void OnCorrect()
    {
        //Debug.Log("Sample Buff On Correct");
    }

    public override void OnIncorrect()
    {
        //Debug.Log("Sample Buff On Incorrect");
    }

    public override void OnAny()
    {
        //Debug.Log("Sample Buff On Any");
    }

    public override void OnCorrectSubmission()
    {
        //Debug.Log("Sample Buff On Correct Submission");
    }

    public override void OnIncorrectSubmission()
    {
        //Debug.Log("Sample Buff On Incorrect Submission");
    }

    public override void OnCorrectRejection()
    {
        //Debug.Log("Sample Buff On Correct Rejection");
    }

    public override void OnIncorrectRejection()
    {
        //Debug.Log("Sample Buff On Incorrect Rejection");
    }
}
