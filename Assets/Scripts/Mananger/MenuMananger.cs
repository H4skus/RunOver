using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMananger : MonoBehaviour
{
    public Animation Menu;
    public InventoryObject Player_Inventory;
    public InventoryObject Run_Inventory;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Player_Inventory.Load();
    }

    public void ShowInventory()
    {
        Menu.Play("Inventory");
    }
    public void UnShowInventory()
    {
        Menu.Play("Inventory_reverse");
    }


    public void StartRun()
    {
        Player_Inventory.Save();
        SceneManager.LoadScene(2);
    }
}
