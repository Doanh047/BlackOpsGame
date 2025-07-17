using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ManageHighScore : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // This script is intended to manage high scores in a game, including saving and loading them.
    Highscore[] highscorer;
    public string newName;
    public int newScore;
    FileManager manager = new FileManager();
    private string location;
    void Start()
    {
        location = Application.persistentDataPath + "/highscore.json";
        manager.PrepareFile(location);
        HighscoreArray arr = manager.ReadFile(location);
        highscorer = arr.highscores;
        Debug.Log(JsonUtility.ToJson(highscorer));
        HandleNewScore();
        GameObject[] objs = getAllChildGameObject();
        ShowScores(objs);
    }

    private void ShowScores(GameObject[] tops)
    {
        for (int i = 0; i < 5; ++i)
        {
            TextMeshProUGUI nameTMP = GetTextMeshPro(tops[i], "Username");
            TextMeshProUGUI scoreTMP = GetTextMeshPro(tops[i], "Score");
            nameTMP.text = highscorer[i].Name;
            scoreTMP.text = highscorer[i].Score.ToString();
        }
    }

    private TextMeshProUGUI GetTextMeshPro(GameObject parent, string name)
    {
        var child = parent.transform.Find(name);
            if (child == null)
            throw new System.Exception("Top not set");
        TextMeshProUGUI childText = child.GetComponent<TextMeshProUGUI>();
        return childText;
    }
    private void HandleNewScore()
    {
        HighscoreArray arr = manager.ReadFile(location);
        highscorer = arr.highscores;
        for (int i = 0; i < 5; ++i)
        {
            if (newScore > highscorer[i].Score)
            {
                highscorer[i] = new Highscore(newName, newScore);
                break;
            }
        }
        string json = JsonUtility.ToJson(new HighscoreArray(highscorer), true);
        manager.WriteToFile(location, json);
    }

    private GameObject[] getAllChildGameObject()
    {
        GameObject[] childObjects = new GameObject[transform.childCount];
        // Loop through each child and store them in the array
        for (int i = 0; i < 5; i++)
        {
            // Get the child Transform and then access its GameObject
            childObjects[i] = transform.GetChild(i).gameObject;
        }

        return childObjects;
    }

    public string GetStringFromChild(GameObject parent, string tmpName)
    {
        var child = parent.transform.Find(tmpName);
        if (child == null)
            throw new System.Exception("Top not set");
        TextMeshProUGUI childText = child.GetComponent<TextMeshProUGUI>();
        return childText.text;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
