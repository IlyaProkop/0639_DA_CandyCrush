using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CupsFillingController : MonoBehaviour
{
    [SerializeField] Image[] fills = new Image[2];

    private int startTime;
    private int currentTime;

    private float currentFill;

    public void InitTime(int startTime)
    {
        this.startTime = startTime;
        foreach (Image fill in fills)
        {
            fill.fillAmount = 0;
        }
    }

    public void CupsFill(int currentTimes)
    {
        this.currentTime = currentTimes;
        float targetFill = (float)(startTime - currentTime) / (float)startTime;

        foreach (Image fill in fills)
        {
            fill.DOKill(); // Остановим текущие анимации для предотвращения конфликтов
            fill.DOFillAmount(targetFill, 1f).SetEase(Ease.Linear); // Запускаем анимацию изменения fillAmount
        }
    }
}
