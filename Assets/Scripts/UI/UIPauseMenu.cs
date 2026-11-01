using UnityEngine;
using UnityEngine.UI;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Button btnContinue;
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnMenu;

    private void Start()
    {
        pausePanel.SetActive(false);
    }
    private void OnEnable()
    {
        gameManager.OnPauseChanged += HandlePauseChanged;
        btnContinue.onClick.AddListener(OnBtnContinueClicked);
        btnRetry.onClick.AddListener(OnBtnRetryClicked);
        btnMenu.onClick.AddListener(OnBtnMenuClicked);
    }

    private void OnDisable()
    {
        gameManager.OnPauseChanged -= HandlePauseChanged;
        btnContinue.onClick.RemoveListener(OnBtnContinueClicked);
        btnRetry.onClick.RemoveListener(OnBtnRetryClicked);
        btnMenu.onClick.RemoveListener(OnBtnMenuClicked);
    }
    private void HandlePauseChanged(bool isPaused)
    {
        pausePanel.SetActive(isPaused);
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
}
