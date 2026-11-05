using PlayFab;
using PlayFab.ClientModels;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Progression = PlayFab.ProgressionModels;

[CreateAssetMenu(fileName = "PlayFab", menuName = "Data/PlayFab")]
public class PlayFabSo : ScriptableObject
{
    private const string PlayIdKey = "PlayFabPlayerId";
    private const string BestScoreStat = "BestScore";
    private const string DisplayNameKey = "PlayFabDisplayNameSet";

    private const int LeaderboardSize = 10;

    public event UnityAction OnLoggedIn;
    public event UnityAction<List<Progression.EntityLeaderboardEntry>> OnLeaderboardLoaded;

    private string GetPlayerId()
    {
        if (PlayerPrefs.HasKey(PlayIdKey))
        {
            return PlayerPrefs.GetString(PlayIdKey);
        }
        string newId = System.Guid.NewGuid().ToString();
        PlayerPrefs.SetString(PlayIdKey, newId);
        PlayerPrefs.Save();
        return newId;
    }

    public void Login()
    {
        if (PlayFabClientAPI.IsClientLoggedIn())
            return;
        LoginWithCustomIDRequest request = new LoginWithCustomIDRequest() { CustomId = GetPlayerId(), CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnPlayFabError);
    }

    private void OnLoginSuccess(LoginResult result)
    {
        if (!PlayerPrefs.HasKey(DisplayNameKey))
            SetDisplayName(result.PlayFabId);
        OnLoggedIn?.Invoke();
    }

    private void OnPlayFabError(PlayFabError error)
    {
        Debug.LogWarning(error.GenerateErrorReport());
    }

    public void SubmitScore(int score)
    {
        if (!PlayFabClientAPI.IsClientLoggedIn())
            return;
        Progression.UpdateStatisticsRequest request = new Progression.UpdateStatisticsRequest
        {
            Statistics = new List<Progression.StatisticUpdate>

        {
            new Progression.StatisticUpdate{Name = BestScoreStat, Scores = new List<string> {score.ToString()}}
        }
        };
        PlayFabProgressionAPI.UpdateStatistics(request, OnScoreSubmitted, OnPlayFabError);
    }

    private void OnScoreSubmitted(Progression.UpdateStatisticsResponse result)
    {
        Debug.Log("Score sent");
    }

    public void RequestLeaderboard()
    {
        if (!PlayFabClientAPI.IsClientLoggedIn())
            return;
        Progression.GetEntityLeaderboardRequest request = new Progression.GetEntityLeaderboardRequest
        {
            LeaderboardName = BestScoreStat,
            StartingPosition = 1,
            PageSize = LeaderboardSize
        };
        PlayFabProgressionAPI.GetLeaderboard(request, OnLeaderboardSuccess, OnPlayFabError);
    }

    private void OnLeaderboardSuccess(Progression.GetEntityLeaderboardResponse result)
    {
        OnLeaderboardLoaded?.Invoke(result.Rankings);
    }

    private void SetDisplayName(string playFabId)
    {
        UpdateUserTitleDisplayNameRequest request = new UpdateUserTitleDisplayNameRequest
        {
            DisplayName = "Macrophage-" + playFabId.Substring(0, 4)
        };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameSet, OnPlayFabError);
    }

    private void OnDisplayNameSet(UpdateUserTitleDisplayNameResult result)
    {
        PlayerPrefs.SetInt(DisplayNameKey, 1);
        PlayerPrefs.Save();
    }

}
