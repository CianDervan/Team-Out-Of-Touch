using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
   /* public float elapsedTime; // The amount of time that has elapsed.
   // public static int points; // The player's current points.
    
    public float timeSpent; // How long did it take player to complete level
    public float levelMaxTime = 180; // The player has to complete the level within this time
    public float levelScore = 10; // The player will be awarded of 10 points per remaining second

// Compute the final score
   // score = Math.max(0, levelMaxTime - timeSpent) * levelScore; // 400 points

   // [SerializeField] private Text uiText;*/
   
   
   
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float mainTimer;

    public static int points; 
    public static float timer;
    //private float timer;

    public static int boxesCollected;
    public float scoreSoFar;
    
    public static bool canCount = true;
    public bool doOnce = false;

    public float scoreDecreaseWithTime;
    public float elapsedTime;
    
    // iHaveScoredPoints - every time player puts part in place they get X points depending on how long is left
    // but lose one point every ten seconds until they complete level
    // else if timer greater than zero and player has won the game, points += remaining seconds * 10
    
    // Start is called before the first frame update
    void Start()
    {
        timer = mainTimer;
        elapsedTime = 0;
        points = 0;
        boxesCollected = 0;

    }

    void Update ()
    {
        scoreSoFar = boxesCollected;
        if (boxesCollected == 4)
        {
            FindObjectOfType<GameManager>().YouWon();
        }
        //scoreText.text = points.ToString("Score " + points);// reads as though it adds one hundred to score every ten seconds? dont know why
        scoreText.text = string.Format("Score " + points);//works
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            //uiTextTwo.text = timer.ToString("F");
            System.TimeSpan t = System.TimeSpan.FromSeconds(timer);
            timerText.text = string.Format("Time Left {1:D2}m:{2:D2}s", t.Hours, t.Minutes, t.Seconds, t.Milliseconds);
            elapsedTime = timer;
            
            if (points > 0 && scoreDecreaseWithTime <= Time.time)
            {
                points --;//-= 1;
                //scoreText.text = points.ToString("Score " + points);
                scoreDecreaseWithTime = Time.time + 10f;
                StartCoroutine(ColourAlert(Color.red, .5f));
            }
            
        }
        
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            timerText.text = "0.00";
            timer = 0.0f;
            FindObjectOfType<GameManager>().YouLost();
        }
        // Update your timer every frame.
        //bonusTimer += Time.deltaTime;
    }
    
    IEnumerator ColourAlert (Color colour, float delay) {
        scoreText.color = colour;
        scoreText.fontSize = 42;
        yield return new WaitForSeconds(delay);
        scoreText.fontSize = 36;
        scoreText.color = Color.white;
    }
 
   /* void AssignPoints ()
    {
        // Add points based on how much time has elapsed.
        // The player gets 2 points for finishing at or under 2 seconds,
        // 1 point between 2 and 10 seconds, and no points above ten seconds.
        if (bonusTimer <= 2f)
        {
            points += 2;
        }
        else if (bonusTimer > 2f && bonusTimer <= 10f)
        {
            points += 1;
        }
    }*/


}
