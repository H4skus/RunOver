using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    public GameObject UI;
    public bool isOpen;
    public MouseLook look;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !isOpen)
        {
            UI.SetActive(true);
            isOpen = true;
            Cursor.lockState = CursorLockMode.None;
            look.enabled = false;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && isOpen)
        {
            UI.SetActive(false);
            isOpen = false;
            Cursor.lockState = CursorLockMode.Locked;
            look.enabled = true;
        }
    }

}
