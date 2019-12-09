using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountInTimer : MonoBehaviour
{
    public float currentTime = 0f;
    public float startingTime = 3f;

    public GameObject thisObject;
    
    public TextMeshProUGUI timerText;
    
    [SerializeField] private TextMeshProUGUI countInText;
    // Start is called before the first frame update
    
    void Awake()
    {
        //Score.canCount = false;
    }
    void Start()
    {
        Score.canCount = false;
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        //countInText.text = string.Format ("" + currentTime);
        countInText.text = currentTime.ToString("0");

        if (currentTime <= 5)
        {
            timerText.text = string.Format("READY");
        }
        if (currentTime <= 3)
        {
            timerText.text = string.Format("SET");
        }
        if (currentTime <= 1)
        {
            timerText.text = string.Format("GO");
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            countInText.text = currentTime.ToString("GO!");
            countInText.enabled = false;
            Score.canCount = true;
            thisObject.SetActive(false);
        }
    }
}
