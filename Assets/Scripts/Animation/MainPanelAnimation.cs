using UnityEngine;
using DG.Tweening;
using System;

public class MainPanelAnimation : MonoBehaviour
{
    [SerializeField] GameObject currentScoreImg;
    [SerializeField] GameObject scoreText;
    [SerializeField] GameObject heroIcon;
    [SerializeField] GameObject settingsButton;
    [SerializeField] GameObject playButton;

    private Vector3 heroIconInitialPos;
    private Vector3 currentScoreImgInitialPos;
    private Vector3 playButtonInitialPos;

    private Sequence sequence;

    private void Awake()
    {
        // Save initial positions
        heroIconInitialPos = heroIcon.transform.localPosition;
        currentScoreImgInitialPos = currentScoreImg.transform.localPosition;
        playButtonInitialPos = playButton.transform.localPosition;
    }

    private void OnEnable()
    {
        // Set initial positions before animating
        heroIcon.transform.localPosition = new Vector3(-Screen.width, heroIconInitialPos.y, heroIconInitialPos.z);

        Vector3 randomPos = new Vector3(UnityEngine.Random.Range(-Screen.width, Screen.width), UnityEngine.Random.Range(-Screen.height, Screen.height), 0);
        currentScoreImg.transform.localPosition = randomPos;

        scoreText.transform.localScale = Vector3.zero;
        settingsButton.GetComponent<CanvasGroup>().alpha = 0;

        playButton.transform.localPosition = new Vector3(playButtonInitialPos.x, -Screen.height, playButtonInitialPos.z);

        // Create animation sequence
        sequence = DOTween.Sequence();

        // heroIcon animation: move from left to initial position while rotating
        sequence.Append(heroIcon.transform.DOLocalMove(heroIconInitialPos, 1f).SetEase(Ease.OutBack))
                .Join(heroIcon.transform.DORotate(new Vector3(0, 0, -360), 1f, RotateMode.FastBeyond360).SetEase(Ease.Linear));

        // currentScoreImg animation: move from random position to initial position
        sequence.Join(currentScoreImg.transform.DOLocalMove(currentScoreImgInitialPos, 1f).SetEase(Ease.OutBack));

        // scoreText animation: scale from 0 to 1
        sequence.Append(scoreText.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce));

        // settingsButton animation: fade in
        sequence.Join(settingsButton.GetComponent<CanvasGroup>().DOFade(1, 0.5f).SetEase(Ease.Linear));

        // playButton animation: move from bottom to initial position
        sequence.Append(playButton.transform.DOLocalMove(playButtonInitialPos, 1f).SetEase(Ease.OutBack));

        // Добавим проверку завершения анимации
        sequence.OnComplete(() => Debug.Log("Animation completed"));
    }

    public void PlayReverseAnimation(Action onComplete)
    {
        // Создаем backwardSequence для обратной анимации
        Sequence backwardSequence = DOTween.Sequence();

        // playButton animation: move back to bottom position
        Vector3 playButtonEndPos = playButtonInitialPos;
        playButtonEndPos.y = -Screen.height;
        backwardSequence.Append(playButton.transform.DOLocalMove(playButtonEndPos, 0.5f).SetEase(Ease.InBack).SetSpeedBased());

        // settingsButton animation: fade out
        backwardSequence.Join(settingsButton.GetComponent<CanvasGroup>().DOFade(0, 0.25f).SetEase(Ease.Linear).SetSpeedBased());

        // scoreText animation: scale back to zero
        backwardSequence.Append(scoreText.transform.DOScale(Vector3.zero, 0.25f).SetEase(Ease.InBack).SetSpeedBased());

        // currentScoreImg animation: move back to random position
        Vector3 randomPos = new Vector3(UnityEngine.Random.Range(-Screen.width, Screen.width), UnityEngine.Random.Range(-Screen.height, Screen.height), 0);
        backwardSequence.Join(currentScoreImg.transform.DOLocalMove(randomPos, 0.5f).SetEase(Ease.InBack).SetSpeedBased());

        // heroIcon animation: move back to left position without rotation
        Vector3 heroIconEndPos = heroIcon.transform.localPosition;
        heroIconEndPos.x = -Screen.width;
        backwardSequence.Append(heroIcon.transform.DOLocalMove(heroIconEndPos, 0.5f).SetEase(Ease.InBack).SetSpeedBased());

        // Добавим проверку завершения анимации
        backwardSequence.OnComplete(() =>
        {
            Debug.Log("Backward animation completed");
            onComplete?.Invoke(); // Вызываем onComplete, если он не null
        });

        // Воспроизводим обратную анимацию
        backwardSequence.Play();
    }
}
