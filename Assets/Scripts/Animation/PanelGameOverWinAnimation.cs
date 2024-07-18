using UnityEngine;
using DG.Tweening;

public class PanelGameOverWinAnimation : MonoBehaviour
{
    [SerializeField] GameObject winnerImg;
    [SerializeField] GameObject newRecordImg;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject settingButtons;
    [SerializeField] GameObject restartButtons;
    [SerializeField] GameObject heroIcon;
    [SerializeField] GameObject coolBtn;

    private Vector3 winnerImgStartPos;
    private Vector3 newRecordImgStartPos;
    private Vector3 scoreTextStartPos;
    private Vector3 settingButtonsStartPos;
    private Vector3 restartButtonsStartPos;
    private Vector3 heroIconStartScale;
    private Vector3 coolBtnStartScale;

    private void Awake()
    {
        // Save initial positions from editor mode
        winnerImgStartPos = winnerImg.transform.position;
        newRecordImgStartPos = newRecordImg.transform.position;
        scoreTextStartPos = scoreText.transform.position;
        settingButtonsStartPos = settingButtons.transform.position;
        restartButtonsStartPos = restartButtons.transform.position;
        heroIconStartScale = heroIcon.transform.localScale;
        coolBtnStartScale = coolBtn.transform.localScale;
    }

    private void OnEnable()
    {
        // Animate elements in sequence
        Sequence sequence = DOTween.Sequence();

        coolBtn.transform.DOScale(coolBtnStartScale * 1.1f, 0.5f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);

        // Animate winnerImg: move from top
        sequence.Join(winnerImg.transform.DOMoveY(winnerImgStartPos.y, 0.5f)  // Уменьшаем длительность до 0.5 секунды
            .SetEase(Ease.OutQuad)
            .From(new Vector3(winnerImgStartPos.x, winnerImgStartPos.y + Screen.height, winnerImgStartPos.z)));

        // Animate settingButtons: move from left
        sequence.Join(settingButtons.transform.DOMoveX(settingButtonsStartPos.x, 0.5f)  // Уменьшаем длительность до 0.5 секунды
            .SetEase(Ease.OutQuad)
            .From(new Vector3(settingButtonsStartPos.x - Screen.width, settingButtonsStartPos.y, settingButtonsStartPos.z)));

        // Animate restartButtons: move from right
        sequence.Join(restartButtons.transform.DOMoveX(restartButtonsStartPos.x, 0.5f)  // Уменьшаем длительность до 0.5 секунды
            .SetEase(Ease.OutQuad)
            .From(new Vector3(restartButtonsStartPos.x + Screen.width, restartButtonsStartPos.y, restartButtonsStartPos.z)));


        // Animate heroIcon: scale from 0 to original size
        heroIcon.transform.localScale = Vector3.zero;
        sequence.Join(heroIcon.transform.DOScale(heroIconStartScale, 0.5f)
            .SetEase(Ease.OutBack));


        // Animate newRecordImg: move from right
        sequence.Append(newRecordImg.transform.DOMoveX(newRecordImgStartPos.x, 0.5f)  // Уменьшаем длительность до 0.5 секунды
            .SetEase(Ease.OutQuad)
            .From(new Vector3(newRecordImgStartPos.x + Screen.width, newRecordImgStartPos.y, newRecordImgStartPos.z)));

        // Animate scoreText: fall into place
        sequence.Append(scoreText.transform.DOMove(scoreTextStartPos, 0.5f)  // Уменьшаем длительность до 0.5 секунды
            .SetEase(Ease.OutBounce)
            .From(new Vector3(scoreTextStartPos.x, scoreTextStartPos.y + Screen.height, scoreTextStartPos.z)));

        // Play the sequence
        sequence.Play();
    }

    public void PlayReverseAnimation()
    {
        // Create reverse sequence
        Sequence reverseSequence = DOTween.Sequence();

        // Reverse restartButtons animation
        reverseSequence.Append(restartButtons.transform.DOMoveX(restartButtonsStartPos.x + Screen.width, 0.5f)  // Уменьшаем длительность до 0.5 секунды
            .SetEase(Ease.InQuad));

        // Reverse settingButtons animation
        reverseSequence.Append(settingButtons.transform.DOMoveX(settingButtonsStartPos.x - Screen.width, 0.5f)  // Уменьшаем длительность до 0.5 секунды
            .SetEase(Ease.InQuad));

        // Reverse scoreText animation
        reverseSequence.Append(scoreText.transform.DOMoveY(scoreTextStartPos.y + Screen.height, 0.5f)  // Уменьшаем длительность до 0.5 секунды
            .SetEase(Ease.InQuad));

        // Reverse newRecordImg animation
        reverseSequence.Append(newRecordImg.transform.DOMoveX(newRecordImgStartPos.x + Screen.width, 0.5f)  // Уменьшаем длительность до 0.5 секунды
            .SetEase(Ease.InQuad));

        // Reverse winnerImg animation
        reverseSequence.Append(winnerImg.transform.DOMoveY(winnerImgStartPos.y + Screen.height, 0.5f)  // Уменьшаем длительность до 0.5 секунды
            .SetEase(Ease.InQuad));

        // Play the reverse sequence
        reverseSequence.Play();
    }
}
