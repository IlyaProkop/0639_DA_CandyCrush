using TMPro;
using UnityEngine;

public class LevelTime : LevelCondition
{
    private float m_time;

    private GameManager m_mngr;

    public override void Setup(float value, TextMeshProUGUI txt, GameManager mngr)
    {
        base.Setup(value, txt, mngr);

        m_mngr = mngr;

        m_time = value;

        UpdateText();
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
       
    }
}
