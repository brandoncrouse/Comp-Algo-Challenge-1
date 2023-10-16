using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour
{
    public GameObject loadThing;
    public GameObject selectScreen, mainMenu;

    public void Play()
    {
        if (loadThing.activeSelf == false)
        {
            loadThing.SetActive(true);
            Invoke("FinishLoad",1.1f);
        }
    }

    void FinishLoad()
    {
        selectScreen.SetActive(true);
        mainMenu.SetActive(false);
    }
}
