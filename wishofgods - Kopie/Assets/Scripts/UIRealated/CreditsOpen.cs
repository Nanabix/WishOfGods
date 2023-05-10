using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsOpen : MonoBehaviour
{
    [SerializeField] private CreditsPage CreditsUI;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {

            if (CreditsUI.isActiveAndEnabled == false)
            {
                CreditsUI.Show();
                
            }



        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            CreditsUI.Hide();
           
        }


    }

}
