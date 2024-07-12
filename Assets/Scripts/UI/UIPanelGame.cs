﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelGame : MonoBehaviour,IMenu
{
    public TextMeshProUGUI LevelConditionView;

    [SerializeField] private Button btnPause;
    [SerializeField] private Button btnRestart;

    private UIMainManager m_mngr;

    private void Awake()
    {
        btnPause.onClick.AddListener(OnClickPause);
        //   btnRestart.onClick.AddListener(OnClickRestart);
        Debug.Log("bntRestr");
    }

    private void OnClickRestart()
    {
        m_mngr.RestartGame();
    }

    private void OnClickPause()
    {
        m_mngr.ShowPauseMenu();
    }

    public void Setup(UIMainManager mngr)
    {
        m_mngr = mngr;
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

}
