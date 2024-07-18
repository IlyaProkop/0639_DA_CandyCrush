using TMPro;
using UnityEngine;

public class GameModeBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameScoreText;

    public bool GameIsWIN()
    {
        ScoreController scoreController = FindAnyObjectByType<ScoreController>();
        bool isTrue = GameScore > scoreController.Score;
        if (isTrue) scoreController.Score = GameScore;

        return true;
        return isTrue;
    }

    private int gameScore;
    public int GameScore
    {
        get
        {
            return gameScore;
        }
        set
        {
            gameScore = value;
            gameScoreText.text = gameScore.ToString();

        }
    }
    private void OnEnable()
    {
        StartGame();
    }
    public void StartGame()
    {
        GameScore = 0;
    }

}
