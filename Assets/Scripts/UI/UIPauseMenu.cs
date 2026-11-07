using System;
using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UIHowToPlay uiHowToPlay;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject howToPlayPanel;
    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnHowToPlay;
    [SerializeField] private Button btnBackHowToPlay;
    [SerializeField] private Button btnBackSettings;
    [SerializeField] private Button btnSettings;

    private void Start()
    {
        pausePanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }
    private void OnEnable()
    {
        gameManager.OnPauseChanged += HandlePauseChanged;
        btnContinue.onClick.AddListener(OnBtnContinueClicked);
        btnRetry.onClick.AddListener(OnBtnRetryClicked);
        btnMenu.onClick.AddListener(OnBtnMenuClicked);
        btnHowToPlay.onClick.AddListener(OnBtnHowToPlayClicked);
        btnBackHowToPlay.onClick.AddListener(OnBtnBackHowToPlayClicked);
        btnSettings.onClick.AddListener(OnBtnSettingsClicked);
        btnBackSettings.onClick.AddListener(OnBtnBackSettingsClicked);
    }

    private void OnDisable()
    {
        gameManager.OnPauseChanged -= HandlePauseChanged;
        btnContinue.onClick.RemoveListener(OnBtnContinueClicked);
        btnRetry.onClick.RemoveListener(OnBtnRetryClicked);
        btnMenu.onClick.RemoveListener(OnBtnMenuClicked);
        btnHowToPlay.onClick.RemoveListener(OnBtnHowToPlayClicked);
        btnBackHowToPlay.onClick.RemoveListener(OnBtnBackHowToPlayClicked);
        btnSettings.onClick.RemoveListener(OnBtnSettingsClicked);
        btnBackSettings.onClick.AddListener(OnBtnBackSettingsClicked);
    }


    private void HandlePauseChanged(bool isPaused)
    {
        pausePanel.SetActive(isPaused);
        if(!isPaused)
        {
            howToPlayPanel.SetActive(false);
            settingsPanel.SetActive(false);
        }
    }
    private void OnBtnContinueClicked()
    {
        gameManager.SetPaused(false);

    }

    private void OnBtnRetryClicked()
    {
        gameManager.Retry();
    }

    private void OnBtnMenuClicked()
    {
        gameManager.GoToMenu();
    }
    private void OnBtnHowToPlayClicked()
    {
        pausePanel.SetActive(false);
        howToPlayPanel.SetActive(true);
        uiHowToPlay.Open();
    }
    private void OnBtnSettingsClicked()
    {
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }
    private void OnBtnBackSettingsClicked()
    {
        pausePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    private void OnBtnBackHowToPlayClicked()
    {
        pausePanel.SetActive(true);
        howToPlayPanel.SetActive(false);
    }
}
