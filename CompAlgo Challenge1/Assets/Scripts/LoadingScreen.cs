using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LoadingScreen : MonoBehaviour
{
    public Sprite loadedSprite, unloadedSprite;

    void OnEnable()
    {
        transform.position = new Vector2(22f, 0f);
        transform.DOMoveX(0,0.66f).SetEase(Ease.OutQuad);
        Invoke("FinishLoad",1.1f);
    }

    void FinishLoad()
    {
        GetComponent<SpriteRenderer>().sprite = loadedSprite;
        Invoke("FinishLoad2",0.17f);
    }

    void FinishLoad2()
    {
        transform.DOMoveX(-22,0.66f).SetEase(Ease.InQuad);
        Invoke("DoneLoading",0.66f);
    }

    void DoneLoading()
    {
        GetComponent<SpriteRenderer>().sprite = unloadedSprite;
        gameObject.SetActive(false);
    }
}
