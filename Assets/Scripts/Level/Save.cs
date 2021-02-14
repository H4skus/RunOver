using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    float timeToEscape = 0;
    float dur = 10f;
    public InventoryObject RunInventory;
    public InventoryObject PlayerInvetnroy;
    public InventoryObject EquipmentInventory;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {

            Debug.Log(timeToEscape);
            if (dur <= timeToEscape)
            {
                GoOut();
            }
            else
            {
            timeToEscape += Time.deltaTime;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            timeToEscape = 0;
    }
    public void GoOut()
    {
        for (int i = 0; i < RunInventory.Container.Items.Length; i++)
        {
            PlayerInvetnroy.AddItem(RunInventory.Container.Items[i].item, RunInventory.Container.Items[i].amount);
        }
        PlayerInvetnroy.Save();
        EquipmentInventory.Save();
        RunInventory.Container.Items = new InventorySlot[20];
        SceneManager.LoadScene("MainMenu");
    }
}
