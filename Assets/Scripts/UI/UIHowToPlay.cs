using UnityEngine;
using UnityEngine.UI;

public class UIHowToPlay : MonoBehaviour
{
    [SerializeField] private GameObject[] slides;
    
    private int currentIndex;

    [SerializeField] private Button btnNext;
    [SerializeField] private Button btnPrev;

    private void OnEnable()
    {
        btnNext.onClick.AddListener(OnBtnNextClicked);
        btnPrev.onClick.AddListener(OnBtnPrevClicked);
    }

    private void OnDisable()
    {
        btnNext.onClick.RemoveListener(OnBtnNextClicked);
        btnPrev.onClick.RemoveListener(OnBtnPrevClicked);
    }

    private void OnBtnNextClicked()
    {
        Next();
    }

    private void OnBtnPrevClicked()
    {
        Previous();
    }

    public void Open()
    {
        currentIndex = 0;
        ShowSlide(currentIndex);
    }

    private void ShowSlide(int index)
    {
        for (int i = 0; i < slides.Length; i++)
        {
            slides[i].SetActive(i == index);
        }
    }

    public void Next()
    {
        if (currentIndex >= slides.Length - 1)
        {
            return;
        }
        currentIndex++;
        ShowSlide(currentIndex);
    }

    public void Previous()
    {
        if (currentIndex <= 0)
            return;
        currentIndex--;
        ShowSlide(currentIndex);
    }

}
