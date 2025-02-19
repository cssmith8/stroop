using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, InputListener
{
    public Puzzle activePuzzle;

    public void OnSubmit()
    {
        switch (activePuzzle.solution)
        {
            case true:
                RunProgression.instance.OnCorrectSubmission();
                OnCorrectResponse();
                break;
            case false:
                RunProgression.instance.OnIncorrectSubmission();
                OnIncorrectResponse();
                break;
        }
        RunProgression.instance.OnSubmit();
        OnAnyReponse();
    }

    public void OnReject()
    {
        switch (activePuzzle.solution)
        {
            case true:
                RunProgression.instance.OnIncorrectRejection();
                OnIncorrectResponse();
                break;
            case false:
                RunProgression.instance.OnCorrectRejection();
                OnCorrectResponse();
                break;
        }
        RunProgression.instance.OnReject();
        OnAnyReponse();
    }

    public void OnThird()
    {
        RunProgression.instance.OnThird();
        OnIncorrectResponse();
        OnAnyReponse();
    }

    private void OnCorrectResponse()
    {
        RunProgression.instance.OnCorrect();
        HealthManager.instance.ChangeHealth(1);
    }

    private void OnIncorrectResponse()
    {
        RunProgression.instance.OnIncorrect();
        HealthManager.instance.ChangeHealth(-1);
    }

    private void OnAnyReponse()
    {
        RunProgression.instance.OnAny();
        HealthManager.instance.UpdateHealthDisplay();
        Destroy(activePuzzle.gameObject);
        activePuzzle = PuzzleCreator.instance.CreatePuzzle();
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("invoked", 0.5f);
        
    }

    void invoked()
    {
        InputManager.instance.RegisterListener(this);
        activePuzzle = PuzzleCreator.instance.CreatePuzzle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
