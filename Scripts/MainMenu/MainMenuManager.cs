using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject instructionsPanel;
    public GameObject mainMenuButtons;
    public GameObject memberPanel;
    public GameObject blackoutOps;
    public GameObject highScoreBoard;
    public GameObject panelScoreBoard;

    public void PlayGame()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
        mainMenuButtons.SetActive(false);
        blackoutOps.SetActive(false); // Hiển thị hiệu ứng mờ
    }

    public void ShowMember()
    {
        memberPanel.SetActive(true);
        mainMenuButtons.SetActive(false);
        blackoutOps.SetActive(false);
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
        mainMenuButtons.SetActive(true);
        blackoutOps.SetActive(true); 
    }
    public void HideMemberPanel()
    {
        memberPanel.SetActive(false);
        mainMenuButtons.SetActive(true);
        blackoutOps.SetActive(true);
    }

    public void ShowHighScoreBoard()
    {
        panelScoreBoard.SetActive(true);
        highScoreBoard.SetActive(true);
        mainMenuButtons.SetActive(false);
        blackoutOps.SetActive(false);  
    }
    public void HideHighScoreBoard()
    {
        highScoreBoard.SetActive(false);
        mainMenuButtons.SetActive(true);
        blackoutOps.SetActive(true);
        panelScoreBoard.SetActive(false);
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false; 
#else
        Application.Quit(); // Thoát thật khi build
#endif
    }
}
