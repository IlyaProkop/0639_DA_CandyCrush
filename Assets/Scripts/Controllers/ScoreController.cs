using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currentScoreText;
    
    private string scoreDATA = "score";

    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            currentScoreText.text = score.ToString();
            PlayerPrefs.SetInt(scoreDATA, value);
        }
    }
   

    private void Start()
    {
        PlayerPrefs.SetInt(scoreDATA, 0);
        Score = PlayerPrefs.GetInt(scoreDATA);
    }
}
