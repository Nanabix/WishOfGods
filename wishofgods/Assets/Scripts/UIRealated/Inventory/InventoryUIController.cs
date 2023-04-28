using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InventoryUIController : MonoBehaviour
{
    [SerializeField] private InventoryPage inventoryUI;
    [SerializeField] private GameObject button;

    public int inventorySize = 24;

    private void Start()
    {
        inventoryUI.InitializeInventoryUI(inventorySize);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {

            if(inventoryUI.isActiveAndEnabled == false)
            {
                inventoryUI.Show();
                button.SetActive(false);
            }
            


        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
                inventoryUI.Hide();
                button.SetActive(true);
        }
            

    }

}
