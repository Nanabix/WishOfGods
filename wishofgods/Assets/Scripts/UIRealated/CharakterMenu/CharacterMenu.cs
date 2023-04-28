using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//in work
public class CharacterMenu : MonoBehaviour
{
    private void Awake()
    {
        Hide();
    }
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
