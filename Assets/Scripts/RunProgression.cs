using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunProgression : MonoBehaviour
{
    public List<Buff> buffs = new List<Buff>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnSubmit()
    {
        foreach (Buff buff in buffs)
        {
            buff.OnSubmit();
        }
    }

    public void OnReject()
    {
        foreach (Buff buff in buffs)
        {
            buff.OnReject();
        }
    }

    public void OnThird()
    {
        foreach (Buff buff in buffs)
        {
            buff.OnThird();
        }
    }

    public void OnCorrect()
    {
        foreach (Buff buff in buffs)
        {
            buff.OnCorrect();
        }
    }

    public void OnIncorrect()
    {
        foreach (Buff buff in buffs)
        {
            buff.OnIncorrect();
        }
    }

    public void OnAny()
    {
        foreach (Buff buff in buffs)
        {
            buff.OnAny();
        }
    }
}
