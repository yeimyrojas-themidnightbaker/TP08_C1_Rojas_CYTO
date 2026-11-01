using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameOverMenu : MonoBehaviour
{
    [SerializeField] private GameResultsSo gameResultsData;
    [SerializeField] private RunProgressSo runProgressData;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TMP_Text winText;
    [SerializeField] private TMP_Text aminoacidText;

    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnExit;

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
btnExit.gameObject.SetActive(false);
#endif
        if (gameResultsData.Won)
        {
            backgroundImage.color = Color.magenta;
            winText.text = "InfeccionEliminada";
        }
        else
        {
            backgroundImage.color = Color.black;
            winText.text = "El macrofago cayo";
        }
        aminoacidText.text = "Aminiacidos x" + runProgressData.CurrentAminoacid;
    }

    private void OnEnable()
    {
        btnRetry.onClick.AddListener(OnBtnRetryClicked);
        btnMenu.onClick.AddListener(OnBtnMenuClicked);
        btnExit.onClick.AddListener(OnBtnExitClicked);
    }
    private void OnDisable()
    {
        btnRetry.onClick.RemoveListener(OnBtnRetryClicked);
        btnMenu.onClick.RemoveListener(OnBtnMenuClicked);
        btnExit.onClick.RemoveListener(OnBtnExitClicked);
    }

    private void OnBtnRetryClicked()
    {
        SceneManager.LoadScene(SceneNames.Gameplay);
    }
    private void OnBtnMenuClicked()
    {
        SceneManager.LoadScene(SceneNames.MainMenu);
    }

    private void OnBtnExitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
Application.Quit();
#endif
    }
}
