using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class MenuAnimation : MonoBehaviour
{
    public float duration;
    public float textDuration;
    public Ease ease;
    public Ease sliderEase;
    public float buttonScale;

    [SerializeField] private Text coin;
    [SerializeField] private Text gem;
    [SerializeField] private Slider coinSlider;
    [SerializeField] private Slider gemSlider;
    [SerializeField] private Button claimButton;
    [SerializeField] private TextMeshProUGUI congratsText;

    private int coinQuantity;
    private int gemQuantity;
    private void Start()
    {
        coinQuantity = Random.Range(1000, 6000);
        gemQuantity = Random.Range(20, 100);

        transform.localScale = Vector3.zero;
    }

    public void Open()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(transform.DOScale(Vector3.one, duration).SetEase(ease)).
            AppendCallback(QuantityDisplay);

        StartCoroutine(Congrats());
            
    }

    public void Close()
    {
        transform.DOScale(Vector3.zero, duration).SetEase(ease);
    }

    private void QuantityDisplay()
    {
        coin.DOText(coinQuantity.ToString(), textDuration);
        coinSlider.DOValue(coinQuantity, textDuration).SetEase(sliderEase);

        gem.DOText(gemQuantity.ToString(), textDuration);
        gemSlider.DOValue(gemQuantity, textDuration).SetEase(sliderEase);   
    }

    IEnumerator Congrats()
    {
        yield return new WaitForSeconds(textDuration + 1);

        congratsText.text = "Congratulation!!";
    }
}
