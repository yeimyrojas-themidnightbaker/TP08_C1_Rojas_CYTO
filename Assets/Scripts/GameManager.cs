using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameResultsSo gameResultsData;
    [SerializeField] private GameDataSo gameData;
    [SerializeField] private RunProgressSo runProgressData;
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private BiofilmBoss biofilmBoss;
    private bool gameEnded;
    public bool GameEnded => gameEnded;

    private bool isPaused;
    public bool IsPaused => isPaused;

    public event UnityAction<bool> OnPauseChanged;
    private void Start()
    {
        runProgressData.ResetRun();
    }

    private void OnEnable()
    {
        playerHealth.OnDied += HandlePlayerDied;
        biofilmBoss.OnBossDefeated += HandleBossDied;
    }

    private void OnDisable()
    {
        playerHealth.OnDied -= HandlePlayerDied;
        biofilmBoss.OnBossDefeated -= HandleBossDied;
    }

    private void Update()
    {
        if (gameEnded)
            return;
        if(AnyKeyDown(gameData.PauseKeys))
        {
            SetPaused(!isPaused);
        }
    }

    private void HandlePlayerDied()
    {
        EndGame(false);
    }

    private void HandleBossDied()
    {
        EndGame(true);
    }

    private void EndGame(bool won)
    {
        if (gameEnded) return;
        gameEnded = true;
        gameResultsData.SetResult(won);
        Invoke(nameof(LoadGameOver), gameData.EndDelay);

    }
    private void LoadGameOver()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneNames.GameOver);
    }

    public void SetPaused(bool paused)
    {
        isPaused = paused;
        Time.timeScale = paused ? 0f : 1f;
        OnPauseChanged?.Invoke(isPaused);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneNames.Gameplay);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneNames.MainMenu);
    }
    private bool AnyKeyDown(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
            if (Input.GetKeyDown(key)) return true;
        return false;
    }
}
