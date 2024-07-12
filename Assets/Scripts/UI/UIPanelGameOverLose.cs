using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelGameOverLose : MonoBehaviour, IMenu
{
    [SerializeField] private Button btnClose;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] GameModeBehaviour game;

    private UIMainManager m_mngr;

    private void Awake()
    {
        btnClose.onClick.AddListener(OnClickClose);
    }

    private void OnDestroy()
    {
        if (btnClose) btnClose.onClick.RemoveAllListeners();
    }

    private void OnClickClose()
    {
        m_mngr.ShowMainMenu();
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Setup(UIMainManager mngr)
    {
        m_mngr = mngr;
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
        scoreText.text = game.GameScore.ToString();
    }

}
