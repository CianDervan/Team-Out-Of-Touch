using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    
    // Tut Flow = 3 seconds pass and text pops explaining on screen controls, buttons, text and objectives. Establish logical order, like
    // do i get them to use particular button then move on
    
   // [SerializeField] private TextMeshProUGUI tutorialTimerText;
   // [SerializeField] private TextMeshProUGUI tutorialScoreText;
   // [SerializeField] private TextMeshProUGUI tutorialKMenuText;
   // [SerializeField] private TextMeshProUGUI tutorialGrabText;
   // [SerializeField] private TextMeshProUGUI tutorialMoveText;
   // [SerializeField] private TextMeshProUGUI tutorialInstructionText;
   // [SerializeField] private TextMeshProUGUI tutorialInMenuText;

   // public GameObject TutorialPanelOne;
    public GameObject TutorialBeginPanel;
    public float tutDelays = 10f;
    

   // public GameObject ControlsCanvas;
  //  public Camera beginCamera;

  void Start()
  {
      //Time.timeScale = 0f;
     // TutorialFlow();
  }
  
  public void TutorialFlow()
  {
      Invoke("StopTime", tutDelays);
  }
  
  public void LetsPlay()
  {
     // SceneManager.LoadScene(SceneManager.LoadScene(02));
  }
   
  public void TutorialOverlay()
  {
      TutorialBeginPanel.SetActive(true);
  }

   public void StopTime()
   {
       Time.timeScale = 0f;
       Score.canCount = false;

   }
   public void StartTime()
   {
       Time.timeScale = 1f;
       Score.canCount = true;
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

   public void MenuMain()
   {
       Score.canCount = false;
       //ControlsCanvas.SetActive(false);
       //beginCamera.enabled = true;

   }

   public void BeginTutorial()
   {
      // beginCamera.enabled = false;
       Score.canCount = false;
   }
   
}
