using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelCondition : MonoBehaviour
{
    public event Action ConditionCompleteEvent = delegate { };

    protected TextMeshProUGUI m_txt;

    protected bool m_conditionCompleted = false;

    public virtual void Setup(float value, TextMeshProUGUI txt)
    {
        m_txt = txt;
    }

    public virtual void Setup(float value, TextMeshProUGUI txt, GameManager mngr)
    {
        m_txt = txt;
    }

    public virtual void Setup(float value, TextMeshProUGUI txt, BoardController board)
    {
        m_txt = txt;
    }

    protected virtual void UpdateText() { }

    protected void OnConditionComplete()
    {
        m_conditionCompleted = true;

        ConditionCompleteEvent();
    }

    protected virtual void OnDestroy()
    {

    }
}
