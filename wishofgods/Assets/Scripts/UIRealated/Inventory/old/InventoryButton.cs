using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] private GameObject Inventory;
    [SerializeField] private GameObject Button;

    private void Start()
    {
        Inventory.SetActive(false);
        Button.SetActive(true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Inventory.SetActive(true);
            Button.SetActive(false);

            
        }
        else if (Input.GetKeyDown(KeyCode.I) || Input.GetKeyDown(KeyCode.Escape))
        {
            Inventory.SetActive(false);
            Button.SetActive(true);
        }
    }
   
}
