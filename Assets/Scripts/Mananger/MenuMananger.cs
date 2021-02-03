using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMananger : MonoBehaviour
{
    public GameObject MenuButtons;
    public InventoryObject Inventory;
    public GameObject LookInventory;
    public Animation Menu;
    public Animation Inventory_anim;
    public GameObject MenuMain;
    public GameObject InventoryMenu;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Inventory.Load();
    }

    public void ShowInventory()
    {
        Menu.Play("MainMenu");
        Inventory_anim.Play("MainMenu_Inventory");
        StartCoroutine(MenuOut());
    }

    IEnumerator MenuOut()
    {
        yield return new WaitForSeconds(0.4f);
        MenuMain.SetActive(false);
        InventoryMenu.SetActive(true);
    }
    IEnumerator MenuIn()
    {
        yield return new WaitForSeconds(0.4f);
        MenuMain.SetActive(true);
        InventoryMenu.SetActive(true);
    }
    public void UnShowInvetory()
    {
        Menu.Play("MainMenuReverse");
        Inventory_anim.Play("MainMenu_InventoryReverse");
        StartCoroutine(MenuIn());
    }
    public void StartRun()
    {
        SceneManager.LoadScene(1);
    }
}
