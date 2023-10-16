using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TitleController : MonoBehaviour
{
    public GameObject titleScreen, mainMenu, loadingThing;
    public Transform knight, transition, bg, load;
    public SpriteRenderer knightSR, bgSR, bgSR2, partSR, loadSR;
    public Sprite[] knightSprites, bgSprites, loadSprites;
    public Animator partAnim;
    public RuntimeAnimatorController[] partControllers;
    public int currentKnight;
    Vector3 knightStart, transitionStart, bgStart;
    bool canLoad = true;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("NewKnight",4f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        bg.position = new Vector2(bg.position.x - Time.deltaTime * 15f, 0f);
        if (bg.position.x < 0f)
        {
            bg.position = new Vector2(19.09f, 0f);
        }
        if (Input.GetKeyDown(KeyCode.Return) && canLoad)
        {
            canLoad = false;
            loadingThing.SetActive(true);
            Invoke("FinishLoad",1.1f);
        }
    }

    void NewKnight()
    {
        transition.position = new Vector2(-21f, 0f);
        transition.DOMoveX(21,1).SetEase(Ease.Linear);
        Invoke("NewKnight2",0.5f);
    }

    void FinishLoad()
    {
        titleScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    void NewKnight2()
    {
        knight.position = new Vector2(21f, 0f);
        currentKnight++;
        currentKnight = currentKnight % 4;
        knightSR.sprite = knightSprites[currentKnight];
        bgSR.sprite = bgSprites[currentKnight];
        bgSR2.sprite = bgSprites[currentKnight];
        partAnim.runtimeAnimatorController = partControllers[currentKnight];
        if (currentKnight == 1 || currentKnight == 2)
        {
            knight.position = new Vector2(-21f, 0f);
        }
        Invoke("SlideKnightIn",1f);

    }

    void SlideKnightIn()
    {
        knight.DOMoveX(0,1).SetEase(Ease.OutQuad);
    }
}
