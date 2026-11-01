using UnityEngine;
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
        SceneManager.LoadScene(SceneNames.GameOver);
    }
    private bool AnyKeyDown(KeyCode[] keys)
    {
        foreach (KeyCode key in keys)
            if (Input.GetKeyDown(key)) return true;
        return false;
    }
}
