using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DailyRewardButton : MonoBehaviour
{
    public float duration;
    public float scaleSize;

    private void Start()
    {
        Shake();
    }
    public void Shake()
    {
        transform.DOScale(Vector3.one * scaleSize, duration).SetLoops(-1, LoopType.Yoyo);
    }
}
