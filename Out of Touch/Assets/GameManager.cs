using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameLost = false;
    public bool gameWon = false;
    
    private bool playAgain = false;

    public float restartDelay = 2f;
    public float gameOverDelay = 8f;

    public GameObject YouWonUIPanel;
    public GameObject YouLostUIPanel;

    public GameObject WinScoreDisplay;
    public GameObject LoseScoreDisplay;

    public GameObject EndKMenuBackground;
    public GameObject KMenuObject;
    
   public void GameOver()
    {
        if (gameLost == false)
        {
            gameLost = true;
            YouLost();
        }
        
        if (gameWon == false)
        {
            gameWon = true;
            YouWon();
        }

        if (playAgain == false)
        {
            playAgain = true;
            Invoke("Restart", restartDelay);
        }
    }

   public void YouLost()
   {
       Score.canCount = false;
       YouLostUIPanel.SetActive(true);
       LoseScoreDisplay.GetComponent<TextMeshProUGUI>().text = string.Format("Score " + Score.points);
       //Invoke("StopTime", gameOverDelay);
   }

   public void YouWon()
   {
       Score.canCount = false;
       YouWonUIPanel.SetActive(true);
       WinScoreDisplay.GetComponent<TextMeshProUGUI>().text = string.Format("Score " + Score.points);
       //Invoke("StopTime", gameOverDelay);
   }

   public void Restart()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       Time.timeScale = 1;
       Score.canCount = true;
   }
   
   public void QuitGame()
   {
       Application.Quit();
   }

   public void KnowledgeMenuAccess()
   {
       //if (YouWonUIPanel || YouLostUIPanel)
       //{
           EndKMenuBackground.SetActive(true);
           //YouWonUIPanel.SetActive(false);
           YouWonUIPanel.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
           YouWonUIPanel.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
           //YouLostUIPanel.SetActive(false);
           YouLostUIPanel.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
           YouLostUIPanel.GetComponentInChildren<TextMeshProUGUI>().enabled = false;
           //Time.timeScale = 1;
           KMenuObject.GetComponent<MenuOpen>().OpenMenu();
      // }
   }

   public void StopTime()
   {
       Time.timeScale = 0f;
   }
   public void StartTime()
   {
       Time.timeScale = 1f;
   }
}
