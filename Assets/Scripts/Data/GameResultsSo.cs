using UnityEngine;
[CreateAssetMenu(fileName = "GameResultsData", menuName = "Data/GameResultsData")]
public class GameResultsSo : ScriptableObject
{
    private bool won;
    public bool Won => won;
    // Suggestion: elapsedTime, timeBonusPoints y capsuleBonusPoints no tienen modificador explícito, mientras won sí tiene private. Unificá el criterio.
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
