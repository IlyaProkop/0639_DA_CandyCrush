using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameModeBehaviour : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI gameScoreText;
    [SerializeField] TextMeshProUGUI floatingTextPrefab;
    [SerializeField] Transform canvasTransform;
    [SerializeField] float floatRange = 50f;

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
            int increment = value - gameScore;
            gameScore = value;
            gameScoreText.text = gameScore.ToString();
            AnimateScoreIncrease(increment);


        }
    }

    private void AnimateScoreIncrease(int increment)
    {
        if (increment <= 0) return;

        TextMeshProUGUI floatingText = Instantiate(floatingTextPrefab, canvasTransform);
        floatingText.text = "+" + increment.ToString();
        floatingText.transform.position = gameScoreText.transform.position;

        // ��������� ����������� ��������
        Vector2 randomDirection = new Vector2(Random.Range(-floatRange, floatRange), Random.Range(-floatRange, floatRange));
        Vector2 targetPosition = floatingText.rectTransform.anchoredPosition + randomDirection;

        // �������� �����������
        floatingText.rectTransform.DOAnchorPos(targetPosition, 1f)
            .SetEase(Ease.OutQuad)
            .OnComplete(() => Destroy(floatingText.gameObject));

        // �������� ������������
        floatingText.DOFade(0, 1f)
            .SetEase(Ease.OutQuad);
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
