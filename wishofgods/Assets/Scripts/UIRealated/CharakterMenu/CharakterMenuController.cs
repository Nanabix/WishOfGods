using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//in work
public class CharakterMenuController : MonoBehaviour
{
    [SerializeField] private CharacterMenu characterMenuUI;
    [SerializeField] private GameObject button;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {

            if (characterMenuUI.isActiveAndEnabled == false)
            {
                characterMenuUI.Show();
                button.SetActive(false);
            }



        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            characterMenuUI.Hide();
            button.SetActive(true);
        }


    }
}
