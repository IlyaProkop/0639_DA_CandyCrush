using TMPro;
using UnityEngine;

public class LevelTime : LevelCondition
{
    private float m_time;

    private GameManager m_mngr;

    private CupsFillingController cupsfillingController;

    public override void Setup(float value, TextMeshProUGUI txt, GameManager mngr)
    {
        base.Setup(value, txt, mngr);


        m_mngr = mngr;

        m_time = value;


        if (cupsfillingController != null)
        {
            cupsfillingController.InitTime((int)value);
        }

        UpdateText();
    }

    private void Awake()
    {
        cupsfillingController = FindAnyObjectByType<CupsFillingController>();

    }

    private void Update()
    {
        if (m_conditionCompleted) return;

        if (m_mngr.State != GameManager.eStateGame.GAME_STARTED) return;

        m_time -= Time.deltaTime;

        UpdateText();

        if (m_time <= -1f)
        {
            OnConditionComplete();
        }
    }

    protected override void UpdateText()
    {
        if (m_time < 0f) return;

        m_txt.text = m_time.ToString("0");
        cupsfillingController.CupsFill((int)m_time);
    }
}
