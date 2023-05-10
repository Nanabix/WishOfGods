using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//in work
public class QuestMenuController : MonoBehaviour
{
    [SerializeField] private QuestMenu questMenuUI;
    [SerializeField] private GameObject button;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {

            if (questMenuUI.isActiveAndEnabled == false)
            {
                questMenuUI.Show();
                button.SetActive(false);
            }



        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            questMenuUI.Hide();
            button.SetActive(true);
        }


    }
}
