using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[System.Serializable]
public class Highscore
{
    [SerializeField]
    private string _name;

    [SerializeField]
    private int _score;

    // Constructor
    public Highscore(string name, int score)
    {
        _name = name;
        _score = score;
    }

    // Public property with proper getter and setter
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int Score
    {
        get { return _score; }
        set { _score = value; }
    }
}

[System.Serializable]
public class HighscoreArray
{
    public Highscore[] highscores;

    public HighscoreArray(Highscore[] highscores)
    {
        this.highscores = highscores;
    }
}