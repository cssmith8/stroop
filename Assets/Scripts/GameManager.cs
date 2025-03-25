using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    RoundStart,
    Round,
    Lose,
    Stats,
    Buffs,
    Debuffs
}

public class GameManager : MonoBehaviour, InputListener
{
    public static GameManager instance;
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
    public Puzzle activePuzzle;

    public GameState gameState = GameState.Round;

    [SerializeField]
    private GameObject statsPanel, shopPrefab, roundStartPrefab;

    [SerializeField]
    private GameObject timerPrefab;

    [HideInInspector]
    private GameObject stats, timer, shop, roundStart;

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
        //activePuzzle = PuzzleCreator.instance.CreatePuzzle();
        RoundOver();
    }

    private void RoundOver()
    {
        UpdateGameState(GameState.Stats);
    }

    // Start is called before the first frame update
    void Start()
    {
        Invoke("RegisterListener", 0.1f);
        UpdateGameState(GameState.RoundStart);
    }

    private void RegisterListener()
    {
        InputManager.instance.RegisterListener(this);
    }

    private void CreateTimer(float seconds = 10f)
    {
        if (timer != null) Destroy(timer);
        timer = Instantiate(timerPrefab, GameObject.FindGameObjectWithTag("TimerAnchor").transform);
        timer.GetComponent<Timer>().BeginTimer(seconds);
    }

    public float GetFractionTimeRemaining()
    {
        if (timer == null) return 0;
        return timer.GetComponent<Timer>().GetFractionTimeRemaining();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTimerExpire()
    {
        if (gameState == GameState.Round)
        {
            UpdateGameState(GameState.Lose);
        }
    }

    public void OnStatsContinue()
    {
        if (gameState == GameState.Stats)
        {
            if (stats != null) Destroy(stats);
            UpdateGameState(GameState.Buffs);
        }
    }

    public void OnBuffsContinue()
    {
        if (gameState == GameState.Buffs)
        {
            if (shop != null) Destroy(shop);
            UpdateGameState(GameState.RoundStart);
        }
    }

    public void OnRoundStartClicked() {
        if (gameState == GameState.RoundStart)
        {
            if (roundStart != null) Destroy(roundStart);
            UpdateGameState(GameState.Round);
        }
    }

    private void UpdateGameState(GameState state)
    {
        gameState = state;
        switch (state)
        {
            case GameState.RoundStart:
                OnRoundStart();
                break;
            case GameState.Round:
                OnRound();
                break;
            case GameState.Lose:
                OnLose();
                break;
            case GameState.Stats:
                OnStats();
                break;
            case GameState.Buffs:
                OnBuffs();
                break;
            case GameState.Debuffs:
                OnDebuffs();
                break;
        }
    }

    private void OnRoundStart()
    {
        if (roundStart != null) Destroy(roundStart);
        roundStart = Instantiate(roundStartPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
        Debug.Log("round start state");
    }

    private void OnRound()
    {
        activePuzzle = PuzzleCreator.instance.CreatePuzzle();
        CreateTimer();
        Debug.Log("round state");
    }

    private void OnLose()
    {
        Destroy(timer);
        Debug.Log("lose state");
    }

    private void OnStats()
    {
        if (timer != null) Destroy(timer);
        if (stats != null) Destroy(stats);
        stats = Instantiate(statsPanel, GameObject.FindGameObjectWithTag("GameCanvas").transform);
        Debug.Log("stats state");
    }

    private void OnBuffs()
    {
        if (shop != null) Destroy(shop);
        shop = Instantiate(shopPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
        Debug.Log("buffs state");
    }

    private void OnDebuffs()
    {
        //shop = Instantiate(evilShopPrefab, GameObject.FindGameObjectWithTag("GameCanvas").transform);
        Debug.Log("debuffs state");
    }
}
