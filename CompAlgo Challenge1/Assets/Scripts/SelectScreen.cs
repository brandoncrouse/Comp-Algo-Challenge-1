using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SelectScreen : MonoBehaviour
{
    public Transform knights;
    public SpriteRenderer button, knightsSR;
    public Sprite buttonOn, buttonOff;
    bool buttonToggled;
    Shader shaderGUItext, shaderSpritesDefault;
    // Start is called before the first frame update
    void Start()
    {
        shaderGUItext = Shader.Find("GUI/Text Shader");
	    shaderSpritesDefault = Shader.Find("Sprites/Default");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !buttonToggled)
        {
            knights.DOMoveY(knights.position.y - 4.6f,0.25f).SetEase(Ease.OutQuad);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && !buttonToggled)
        {
            knights.DOMoveY(knights.position.y + 4.6f,0.25f).SetEase(Ease.OutQuad);
        }
        if (knights.localPosition.y < 0f)
        {
            knights.localPosition = new Vector2(0f, knights.localPosition.y + 4.6f*3f);
        }
        if (knights.localPosition.y > 4.6f*3f)
        {
            knights.localPosition = new Vector2(0f, knights.localPosition.y - 4.6f*3f);
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
             if (buttonToggled)
             {
                UnselectKnight();
             }
             else
             {
                SelectKnight();
             }
        }
    }

    void SelectKnight()
    {
        buttonToggled = true;
        button.sprite = buttonOn;
        StartCoroutine(FlashSprite());
    }

    IEnumerator FlashSprite()
    {
        knightsSR.material.shader = shaderGUItext;
        yield return new WaitForSeconds(0.05f);
        knightsSR.material.shader = shaderSpritesDefault;
        yield return new WaitForSeconds(0.05f);
        knightsSR.material.shader = shaderGUItext;
        yield return new WaitForSeconds(0.05f);
        knightsSR.material.shader = shaderSpritesDefault;
        yield return new WaitForSeconds(0.05f);
        knightsSR.material.shader = shaderGUItext;
        yield return new WaitForSeconds(0.05f);
        knightsSR.material.shader = shaderSpritesDefault;
    }

    void UnselectKnight()
    {
        buttonToggled = false;
        button.sprite = buttonOff;
    }
}
