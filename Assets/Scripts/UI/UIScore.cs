using TMPro;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    [SerializeField] private RunProgressSo runProgressSo;
    [SerializeField] private TMP_Text scoreText;

    private void OnEnable()
    {
        runProgressSo.OnScoreChanged += HandleScoreText;
    }

    private void OnDisable()
    {
        runProgressSo.OnScoreChanged -= HandleScoreText;
    }

    private void HandleScoreText(int newScore)
    {
        scoreText.text = "Score: " + newScore;
    }
}
