using System.Collections;
using UnityEngine;

public class BackgroundZone : MonoBehaviour
{
    [SerializeField] private LevelDataSo levelData;
    [SerializeField] private bool startVisible;

    private SpriteRenderer[] layers;
    private Coroutine currentFade;

    private void Awake()
    {
        layers = GetComponentsInChildren<SpriteRenderer>();
        SetAlpha(startVisible ? 1f : 0f);
    }

    private void SetAlpha(float alpha)
    {
        foreach (SpriteRenderer layer in layers)
        {
            Color color = layer.color;
            color.a = alpha;
            layer.color = color;

        }
    }

    public void FadeTo(float targetAlpha)
    {
        if (currentFade != null)
        {
            StopCoroutine(currentFade);
        }
        currentFade = StartCoroutine(FadeRoutine(targetAlpha));
    }

    private IEnumerator FadeRoutine(float targetAlpha)
    {
        float startAlpha = layers[0].color.a;
        float time = 0f;

        while (time < levelData.BackgroundFadeDuration)
        {
            time += Time.deltaTime;
            float lerp = time / levelData.BackgroundFadeDuration;
            SetAlpha(Mathf.Lerp(startAlpha, targetAlpha, lerp));
            yield return null;

        }

        SetAlpha(targetAlpha);
        currentFade = null;
    }
}
