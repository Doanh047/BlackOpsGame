using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NameInput: MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject Scoreboard;
    public ManageHighScore ManageHighScore;
    public string input = "";
    void Start()
    {
        // Set the text color of the TMP_InputField (user input text)
        inputField.textComponent.color = Color.white;  // You can set any color here
        inputField.textComponent.alignment = TextAlignmentOptions.Center; // Center the text
        inputField.characterLimit = 10;
        inputField.onValueChanged.AddListener(OnTextChanged);
        inputField.onEndEdit.AddListener(OnEndEdit);

    }

    // This function will be called when the input field's text changes
    public void OnTextChanged(string newText)
    {
        input = newText;  // Update input with the new text
    }

    public void OnEndEdit(string inputText)
    {
        // Code to execute when the user finishes input
        Debug.Log("Input finished: " + inputText);

        // Example: You can run your custom logic here
        ManageHighScore.newName = inputText;
        ManageHighScore.newScore = PlayerPrefs.GetInt("Score");
        Scoreboard.SetActive(true);
        gameObject.SetActive(false);
        PlayerPrefs.DeleteAll();
    }

}
