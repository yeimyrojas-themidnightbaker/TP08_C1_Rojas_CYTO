using UnityEngine;
[CreateAssetMenu(fileName = "GameResultsData", menuName = "Data/GameResultsData")]
public class GameResultsSo : ScriptableObject
{
    private bool won;
    public bool Won => won;

    public void SetResult(bool hasWon)
    {
        won = hasWon;
    }
}
