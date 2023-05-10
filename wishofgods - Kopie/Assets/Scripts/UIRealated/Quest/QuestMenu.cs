using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//in work

public class QuestMenu : MonoBehaviour
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
