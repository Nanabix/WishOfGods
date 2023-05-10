using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//add other Menus here
public class MenuCroller : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;
    [SerializeField] private GameObject Button;

    private void Start()
    {
        Inventory.SetActive(false);
        Button.SetActive(true);
    }
    public void OpenInventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(true);
            Button.SetActive(false);
        }
    }

    public void ExitInventory()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
        {
            Inventory.SetActive(false);
            Button.SetActive(true);
        }
    }
}
