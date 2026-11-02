using UnityEngine;
[CreateAssetMenu(fileName = "GameResultsData", menuName = "Data/GameResultsData")]
public class GameResultsSo : ScriptableObject
{
    private bool won;
    public bool Won => won;
    float elapsedTime;
    public float ElapsedTime => elapsedTime;
    int timeBonusPoints;
    public int TimeBonusPoints => timeBonusPoints;

    int capsuleBonusPoints;
    public int CapsuleBonusPoints => capsuleBonusPoints;
    public void SetResult(bool hasWon, float time, int timeBonus, int capsuleBonus)
    {
        won = hasWon;
        elapsedTime = time;
        timeBonusPoints = timeBonus;
        capsuleBonusPoints = capsuleBonus;

    }
}
