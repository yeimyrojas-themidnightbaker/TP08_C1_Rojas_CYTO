using UnityEngine;

public class PlayFabTester : MonoBehaviour
{
    [SerializeField] private PlayFabSo playFab;
    private void Start()
    {
        playFab.Login();
    }
}
