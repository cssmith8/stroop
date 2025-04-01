using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RunProgression : MonoBehaviour
{
    //singleton
    public static RunProgression instance;

    public List<Buff> buffs = new List<Buff>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void AddBuff(Buff buff)
    {
        buffs.Add(buff);
    }

    sealed class RunProgressionAttribute : System.Attribute
    {
        // See the attribute guidelines at
        //  http://go.microsoft.com/fwlink/?LinkId=85236
        readonly string positionalString;
        
        // This is a positional argument
        public RunProgressionAttribute(string positionalString)
        {
            this.positionalString = positionalString;
            
            // TODO: Implement code here
            throw new System.NotImplementedException();
        }
        
        public string PositionalString
        {
            get { return positionalString; }
        }
        
        // This is a named argument
        public int NamedInt { get; set; }
    }

    public List<PuzzleColor> GetPuzzleColors()
    {
        //todo: use debuffs to modify this list
        return new List<PuzzleColor> { PuzzleColor.RED, PuzzleColor.BLUE, PuzzleColor.GREEN, PuzzleColor.YELLOW };
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

    public void OnCorrectSubmission()
    {
        foreach (Buff buff in buffs)
        {
            buff.OnCorrectSubmission();
        }
    }

    public void OnIncorrectSubmission()
    {
        foreach (Buff buff in buffs)
        {
            buff.OnIncorrectSubmission();
        }
    }

    public void OnCorrectRejection()
    {
        foreach (Buff buff in buffs)
        {
            buff.OnCorrectRejection();
        }
    }

    public void OnIncorrectRejection()
    {
        foreach (Buff buff in buffs)
        {
            buff.OnIncorrectRejection();
        }
    }
}
