using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGameOverMenu : MonoBehaviour
{
    [SerializeField] private GameResultsSo gameResultsData;
    [SerializeField] private RunProgressSo runProgressData;
    [SerializeField] private SaveDataSo saveData;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TMP_Text winText;
    [SerializeField] private TMP_Text scoreText;

    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnMenu;
    [SerializeField] private Button btnExit;
    [SerializeField] private Sprite spriteWin;
    [SerializeField] private Sprite spriteLose;

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
btnExit.gameObject.SetActive(false);
#endif
        if (gameResultsData.Won)
        {
            backgroundImage.sprite = spriteWin;
            winText.text = "InfeccionEliminada";
        }
        else
        {
            backgroundImage.sprite = spriteLose;
            winText.text = "El macrofago cayo";
        }
        ShowScore();
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

    private void ShowScore()
    {
        string text = "Score: " + runProgressData.CurrentScore;
        text += "\nRecord " + saveData.BestScore;
        text += "\nAminoacids " + runProgressData.CurrentAminoacid;
        if(saveData.IsNewRecord)
        {
            text += "\n Nuevo record";
        }
        if(gameResultsData.Won)
        {
            text += "\nTime " + FormatTime(gameResultsData.ElapsedTime);
            text += "\nTime Bonus " + gameResultsData.TimeBonusPoints;
            text += "\nCapsuleBonus " + gameResultsData.CapsuleBonusPoints;
        }
        scoreText.text = text;
    }

    private string FormatTime(float seconds)
    {
        int minutes = (int)(seconds / 60f);
        int secs = (int)(seconds % 60);
        return minutes.ToString("00") + ":" + secs.ToString("00");
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
