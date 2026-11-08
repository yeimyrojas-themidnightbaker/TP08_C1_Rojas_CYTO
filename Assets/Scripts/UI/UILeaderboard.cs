using PlayFab.ProgressionModels;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILeaderboard : MonoBehaviour
{
    [SerializeField] private PlayFabSo playFab;
    [SerializeField] private UILeaderboardRow rowPrefab;
    [SerializeField] private Transform rowContainer;
    [SerializeField] private TMP_Text statusText;

    private void Start()
    {
        statusText.text = "Loading records...";
        playFab.Login();
        if (!playFab.IsSubmittingScore)
        {
            playFab.RequestLeaderboard();
        }
    }
    private void OnEnable()
    {
        playFab.OnLoggedIn += HandleLoggedIn;
        playFab.OnLeaderboardLoaded += HandleLeaderboardLoaded;
        playFab.OnScoreSubmittedEvent += HandleScoreSubmitted;
    }

    private void OnDisable()
    {
        playFab.OnLoggedIn -= HandleLoggedIn;
        playFab.OnLeaderboardLoaded -= HandleLeaderboardLoaded;
        playFab.OnScoreSubmittedEvent -= HandleScoreSubmitted;

    }

    private void HandleLoggedIn()
    {
        playFab.RequestLeaderboard();
    }

    private void HandleLeaderboardLoaded(List<EntityLeaderboardEntry> entries)
    {
        foreach (Transform child in rowContainer)
            Destroy(child.gameObject);
        statusText.text = entries.Count == 0 ? "No records yet" : "";

        foreach (EntityLeaderboardEntry entry in entries)
        {
            UILeaderboardRow row = Instantiate(rowPrefab, rowContainer);
            row.SetUp(entry);
        }
    }

    private void HandleScoreSubmitted()
    {
        Invoke(nameof(RequestLeaderboardDelayed), 1.5f);
    }

    private void RequestLeaderboardDelayed()
    {
        playFab.RequestLeaderboard();
    }
}
