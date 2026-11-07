using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private UIDataSo uiData;
    [SerializeField] private UIHowToPlay uiHowToPlay;

    [Header("CanvasGroup")]
    [SerializeField] private CanvasGroup mainPanel;
    [SerializeField] private CanvasGroup settingsPanel;
    [SerializeField] private CanvasGroup howToPlayPanel;
    [SerializeField] private CanvasGroup creditsPanel;
    [SerializeField] private CanvasGroup shopPanel;
    [SerializeField] private CanvasGroup atlasPanel;

    [Header("Botones")]
    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnHowToPlay;
    [SerializeField] private Button btnShop;
    [SerializeField] private Button btnExit;
    [SerializeField] private Button btnAtlas;

    [SerializeField] private Button btnBackSettings;
    [SerializeField] private Button btnBackCredits;
    [SerializeField] private Button btnBackHowToPlay;
    [SerializeField] private Button btnBackShop;
    [SerializeField] private Button btnBackAtlas;

    private Coroutine currentFade;

    private void Start()
    {
        SetPanel(settingsPanel, false);
        SetPanel(creditsPanel, false);
        SetPanel(howToPlayPanel, false);
        SetPanel(shopPanel, false);
        SetPanel(atlasPanel, false);

        SetPanel(mainPanel, true);

#if UNITY_WEBGL && !UNITY_EDITOR
btnExit.gameObject.SetActive(false);
#endif

    }

    private void OnEnable()
    {
        btnPlay.onClick.AddListener(OnBtnPlayClicked);
        btnSettings.onClick.AddListener(OnBtnSettingsClicked);
        btnCredits.onClick.AddListener(OnBtnCreditsClicked);
        btnHowToPlay.onClick.AddListener(OnBtnHowToPlayClicked);
        btnShop.onClick.AddListener(OnBtnShopClicked);
        btnExit.onClick.AddListener(OnBtnExitClicked);
        btnAtlas.onClick.AddListener(OnBtnAtlasClicked);


        btnBackSettings.onClick.AddListener(OnBtnBackSettingsClicked);
        btnBackCredits.onClick.AddListener(OnBtnBackCreditsClicked);
        btnBackHowToPlay.onClick.AddListener(OnBtnBackHowToPlayClicked);
        btnBackShop.onClick.AddListener(OnBtnBackShopClicked);
        btnBackAtlas.onClick.AddListener(OnBtnBackAtlasClicked);
    }


    private void OnDisable()
    {
        btnPlay.onClick.RemoveListener(OnBtnPlayClicked);
        btnSettings.onClick.RemoveListener(OnBtnSettingsClicked);
        btnCredits.onClick.RemoveListener(OnBtnCreditsClicked);
        btnHowToPlay.onClick.RemoveListener(OnBtnHowToPlayClicked);
        btnShop.onClick.RemoveListener(OnBtnShopClicked);
        btnExit.onClick.RemoveListener(OnBtnExitClicked);
        btnAtlas.onClick.RemoveListener(OnBtnAtlasClicked);


        btnBackSettings.onClick.RemoveListener(OnBtnBackSettingsClicked);
        btnBackCredits.onClick.RemoveListener(OnBtnBackCreditsClicked);
        btnBackHowToPlay.onClick.RemoveListener(OnBtnBackHowToPlayClicked);
        btnBackShop.onClick.RemoveListener(OnBtnBackShopClicked);
        btnBackAtlas.onClick.RemoveListener(OnBtnBackAtlasClicked);
    }


    private void OnBtnPlayClicked()
    {
        SceneManager.LoadScene(SceneNames.Gameplay);
    }

    private void OnBtnSettingsClicked() => SwitchPanel(mainPanel, settingsPanel);

    private void OnBtnCreditsClicked() => SwitchPanel(mainPanel, creditsPanel);
    private void OnBtnHowToPlayClicked()
    {
        SwitchPanel(mainPanel, howToPlayPanel);
        uiHowToPlay.Open();
    }
    private void OnBtnShopClicked() => SwitchPanel(mainPanel, shopPanel);
    private void OnBtnAtlasClicked() => SwitchPanel(mainPanel, atlasPanel);
    private void OnBtnExitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;    
#else
Application.Quit();
#endif
    }

    private void OnBtnBackSettingsClicked() => SwitchPanel(settingsPanel, mainPanel);

    private void OnBtnBackCreditsClicked() => SwitchPanel(creditsPanel, mainPanel);

    private void OnBtnBackHowToPlayClicked() => SwitchPanel(howToPlayPanel, mainPanel);
    private void OnBtnBackShopClicked() => SwitchPanel(shopPanel, mainPanel);

    private void OnBtnBackAtlasClicked() => SwitchPanel(atlasPanel, mainPanel);
    private void SetPanel(CanvasGroup panel, bool visible)
    {
        panel.alpha = visible ? 1 : 0;
        panel.interactable = visible;
        panel.blocksRaycasts = visible;
    }

    private void SwitchPanel(CanvasGroup from, CanvasGroup to)
    {
        if (currentFade != null)
            return;
        currentFade = StartCoroutine(FadePanels(from, to));
    }

    private IEnumerator FadePanels(CanvasGroup from, CanvasGroup to)
    {
        from.interactable = false;
        from.blocksRaycasts = false;

        float duration = uiData.PanelFadeDuration;
        float time = 0f;
        while (time < duration)
        {
            time += Time.unscaledDeltaTime;
            float lerp = time / duration;
            from.alpha = 1f - lerp;
            to.alpha = lerp;
            yield return null;
        }
        SetPanel(from, false);
        SetPanel(to, true);
        currentFade = null;
    }
}
