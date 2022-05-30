using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ClaimButton : MonoBehaviour
{
    private bool canClaim;
    public float duration;
    public float shakeStrength;
    private MenuAnimation menu;

    [SerializeField] private TextMeshProUGUI congratsText;

    private void Start()
    {
        menu = GameObject.FindObjectOfType<MenuAnimation>();

        canClaim = true;
        congratsText.transform.localScale = Vector3.zero;
    }
    
    public void ClickClaimButton()
    {
        if (canClaim)
        {
            ClaimReward();
        } else
        {
            CanNotClaimReward();
        }
    }

    private void ClaimReward()
    {
        menu.StopAllCoroutines();

        congratsText.transform.DOScale(Vector3.one, duration);

        canClaim = false;       
    }

    private void CanNotClaimReward()
    {       transform.DOShakePosition(duration, shakeStrength);
            transform.DOShakeRotation(duration, shakeStrength);
            transform.DOShakeScale(duration, shakeStrength);

        congratsText.text = "Tham lam!";

    }

}
