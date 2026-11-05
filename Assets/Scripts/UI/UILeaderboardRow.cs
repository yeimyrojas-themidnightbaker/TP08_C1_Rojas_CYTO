using TMPro;
using UnityEngine;
using Progression = PlayFab.ProgressionModels;


public class UILeaderboardRow : MonoBehaviour
{
    [SerializeField] private TMP_Text rankText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text scoreText;

    public void SetUp(Progression.EntityLeaderboardEntry entry)
    {
        rankText.text = entry.Rank.ToString();
        nameText.text = string.IsNullOrEmpty(entry.DisplayName) ? "Macrophage" : entry.DisplayName;
        scoreText.text = entry.Scores[0];
    }

}
