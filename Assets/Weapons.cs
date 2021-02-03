using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public InventoryObject runInventory;

    private void Start()
    {
    }
    private void Update()
    {
        #region Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            //Reload();
        }
        #endregion
        if (Input.GetMouseButtonDown(0))
        {
            //Shoot();
        }
    }
}
