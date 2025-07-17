using System.Linq;
using System.Threading.Tasks;
using TMPro;
using UnityEditor;
using UnityEngine;

public class FileManager
{

    public void WriteToFile(string filePath, string content)
    {
        if (System.IO.File.Exists(filePath))
            System.IO.File.Delete(filePath);
        System.IO.File.WriteAllText(filePath, content);
    }
    public void PrepareFile(string filePath)
    {
        if (System.IO.File.Exists(filePath) == false)
        {
            // Create a new high score file with default values if it doesn't exist
            Highscore[] highscorer = new Highscore[5];
            for (int i = 0; i < highscorer.Length; i++)
            {
                highscorer[i] = new Highscore("Player" + (i + 1), 0);
            }
            HighscoreArray tempArr = new HighscoreArray(highscorer);
            string temp = JsonUtility.ToJson(tempArr, true);
            System.IO.File.WriteAllText(filePath, temp);
        }
        //Too lazy too deal with optimization :P
    }
    public HighscoreArray ReadFile(string filePath )
    {
        string json = System.IO.File.ReadAllText(filePath);
        HighscoreArray highscoreArray = JsonUtility.FromJson<HighscoreArray>(json);
        return highscoreArray;
    }
}
