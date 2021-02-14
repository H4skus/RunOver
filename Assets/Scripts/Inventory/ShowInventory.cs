using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    public GameObject Inventory;
    public bool isOpen;
    public MouseLook look;
    public GameObject Equipment;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isOpen)
        {
            Inventory.SetActive(true);
            Equipment.SetActive(true);
            isOpen = true;
            Cursor.lockState = CursorLockMode.None;
            look.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isOpen)
        {
            Inventory.SetActive(false);
            Equipment.SetActive(false);
            isOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            look.enabled = true;
        }
    }
}
