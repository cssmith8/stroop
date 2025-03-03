using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    RoundStart,
    Round,
    Stats,
    Buffs,
    Debuffs
}

public class GameManager : MonoBehaviour, InputListener
{
    public Puzzle activePuzzle;

    public static GameState gameState = GameState.Round;

//fix this
    [SerializeField]
    private static GameObject statsPanel;

    public void OnSubmit()
    {
        if (gameState != GameState.Round) return;
        if (activePuzzle == null) return;
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
        if (gameState != GameState.Round) return;
        if (activePuzzle == null) return;
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
        if (gameState != GameState.Round) return;
        if (activePuzzle == null) return;
        RunProgression.instance.OnThird();
        OnIncorrectResponse();
        OnAnyReponse();
    }

    private void OnCorrectResponse()
    {
        RunProgression.instance.OnCorrect();
        //HealthManager.instance.ChangeHealth(1);
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
        Timer.instance.BeginTimer(10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void OnTimerExpire() {
        if (gameState == GameState.Round)
        {
            gameState = GameState.Stats;
            GameObject go = Instantiate(statsPanel, GameObject.FindGameObjectWithTag("GameCanvas").transform);
        }
    }

    public static void OnStatsContinue() {
        if (gameState == GameState.Stats)
        {
            gameState = GameState.Buffs;
            Debug.Log("real");
        }
    }
}
