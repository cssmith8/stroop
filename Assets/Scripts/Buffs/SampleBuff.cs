using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleBuff : Buff
{
    public SampleBuff()
    {
        name = "Sample Buff";
    }

    public override string GetDescription()
    {
        string value = "1";
        switch (NumUpgrades(Upgrade.BLUE))
        {
            case 1:
                value = "2";
                break;
            case 2:
                value = "3";
                break;
            case 3:
                value = "4";
                break;
        }
        return "Heals you for " + BlueWord(value) + " health upon submission.";
    }

    public override void OnSubmit()
    {
        //Debug.Log("Sample Buff On Submit");
        int value = NumUpgrades(Upgrade.RED);
        HealthManager.instance.ChangeHealth(1 + value);
        display.PlayAnimation();
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
