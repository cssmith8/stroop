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
                //Debug.Log("Submitted - Correct");
                OnCorrectResponse();
                break;
            case false:
                //Debug.Log("Submitted - Incorrect");
                OnIncorrectResponse();
                break;
        }
        OnAnyReponse();
    }

    public void OnReject()
    {
        switch (activePuzzle.solution)
        {
            case true:
                //Debug.Log("Rejected - Incorrect");
                OnIncorrectResponse();
                break;
            case false:
                //Debug.Log("Rejected - Correct");
                OnCorrectResponse();
                break;
        }
        OnAnyReponse();
    }

    private void OnCorrectResponse()
    {
        HealthManager.instance.ChangeHealth(1);
    }

    private void OnIncorrectResponse()
    {
        HealthManager.instance.ChangeHealth(-1);
    }

    private void OnAnyReponse()
    {
        HealthManager.instance.UpdateHealthDisplay();
        Destroy(activePuzzle.gameObject);
        activePuzzle = PuzzleCreator.instance.CreatePuzzle();
    }

    public void OnThird()
    {

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
