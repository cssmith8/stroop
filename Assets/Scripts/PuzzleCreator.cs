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

    private PuzzleColor GetRandomPuzzleColor()
    {
        List<PuzzleColor> colors = RunProgression.instance.GetPuzzleColors();
        return colors[Random.Range(0, colors.Count)];
    }

    private PuzzleColor GetRandomPuzzleColorExcept(PuzzleColor color)
    {
        List<PuzzleColor> colors = RunProgression.instance.GetPuzzleColors();
        colors.Remove(color);
        return colors[Random.Range(0, colors.Count)];
    }   

    public Puzzle CreatePuzzle()
    {
        GameObject puzzleObject = Instantiate(puzzlePrefab, transform);
        Puzzle puzzle = puzzleObject.GetComponent<Puzzle>();

        //randomize color
        PuzzleColor c = GetRandomPuzzleColor();
        puzzle.SetColor(c);

        //randomize solution
        bool s = Random.Range(0, 2) == 0;
        puzzle.solution = s;

        //set text
        if (s)
            puzzle.SetText(Puzzle.GetColorString(c));
        else
            puzzle.SetText(Puzzle.GetColorString(GetRandomPuzzleColorExcept(c)));
        
        puzzleObject.transform.SetParent(gameCanvas.transform, false);
        return puzzle;
    }
}
