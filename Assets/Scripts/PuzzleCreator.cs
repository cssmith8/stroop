using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCreator : MonoBehaviour
{
    //singleton
    public static PuzzleCreator instance;

    [SerializeField]
    private GameObject puzzlePrefab;
    [SerializeField]
    private GameObject gameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public Puzzle CreatePuzzle()
    {
        GameObject puzzleObject = Instantiate(puzzlePrefab, transform);
        Puzzle puzzle = puzzleObject.GetComponent<Puzzle>();

        //randomize color
        PuzzleColor c = Random.Range(0, 4) switch
        {
            0 => PuzzleColor.RED,
            1 => PuzzleColor.BLUE,
            2 => PuzzleColor.GREEN,
            3 => PuzzleColor.YELLOW,
            _ => PuzzleColor.RED,
        };

        //randomize solution
        bool s = Random.Range(0, 2) == 0;

        puzzle.SetColor(c);
        puzzle.solution = s;
        switch (c)
        {
            case PuzzleColor.RED:
                if (s)
                    puzzle.SetText("RED");
                else
                    puzzle.SetText("BLUE");
                break;
            case PuzzleColor.BLUE:
                if (s)
                    puzzle.SetText("BLUE");
                else
                    puzzle.SetText("RED");
                break;
            case PuzzleColor.GREEN:
                if (s)
                    puzzle.SetText("GREEN");
                else
                    puzzle.SetText("YELLOW");
                break;
            case PuzzleColor.YELLOW:
                if (s)
                    puzzle.SetText("YELLOW");
                else
                    puzzle.SetText("GREEN");
                break;
        }
        
        puzzleObject.transform.SetParent(gameCanvas.transform, false);
        return puzzle;
    }
}
