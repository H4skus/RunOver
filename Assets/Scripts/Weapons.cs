using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class Weapons : MonoBehaviour
{
    WeaponStat test;
    public InventoryObject Equipment;
    public InventoryObject runInventory;
    public Transform pos;
    public GameObject activWeapon;
    public bool hasActive;
    public int activeIndex;
    //WeaponStat WeaponStat;
    //public PistolObject weaponStat;
    [SerializeField] private float zoomInFieldView;

    private float baseFieldOfView;
    public Camera mainCam;




    private void Start()
    {
        //mainCam = GameObject.Find("PlayerCam").GetComponent<Camera>();
        baseFieldOfView = mainCam.fieldOfView;
    }
    private void Update()
    {
        #region Reload
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
        #endregion
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            WeaponCheck(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            WeaponCheck(1);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            test.Fire();
        }

        if (Input.GetMouseButtonDown(1))
        {
            //zoomin
            StopAllCoroutines();
            StartCoroutine(ZoomAnim(true));
        }
        if (Input.GetMouseButtonUp(1))
        {
            //zoomout
            StopAllCoroutines();
            StartCoroutine(ZoomAnim(false));
        }
    }
    public void WeaponCheck(int index)
    {
        if (Equipment.Container.Items[index].ID >= 0 && !hasActive)
        {
            var prefab = Equipment.Container.Items[index].prefab;
            activWeapon = Instantiate(prefab, pos.position , Quaternion.identity);
            activWeapon.transform.parent = pos;
            activWeapon.transform.localEulerAngles = new Vector3(-90, 0, -188.477f);
            Debug.Log(activWeapon.transform.localEulerAngles);
            hasActive = true;
            activeIndex = index;
            test = activWeapon.GetComponent<WeaponStat>();
        }
        else if(activeIndex != index)
        {
            hasActive = false;
            Destroy(activWeapon);
            var prefab = Equipment.Container.Items[index].prefab;
            activWeapon = Instantiate(prefab, pos.position, Quaternion.identity);
            activWeapon.transform.parent = pos;
            activWeapon.transform.localEulerAngles = new Vector3(-90, 0, -188.477f);
            Debug.Log(activWeapon.transform.localEulerAngles);
            hasActive = true;
            activeIndex = index;
            test = activWeapon.GetComponent<WeaponStat>();
        }
    }

    public void Reload()
    {
        for (int i = 0; i < runInventory.Container.Items.Length; i++)
        {
            Debug.Log(runInventory.Container.Items[i].type);
            if (runInventory.Container.Items[i].type == test.ammo)
            {
                if (runInventory.Container.Items[i].amount > 0)
                {
                    test.Reload();
                    runInventory.Container.Items[i].DeleteAmount(1);
                    break;
                }
            }
        }
    }

    private IEnumerator ZoomAnim(bool zoomIn)
    {
        test.ZoomIn(zoomIn);
        float animTime = test.ZoomAnimTime;
        float elapsed = 0f;

        float startFieldOfView = mainCam.fieldOfView;
        float endFieldOfView = (zoomIn) ? zoomInFieldView : baseFieldOfView;
        /*
        if (zoomIn == true)
        {
            endFieldOfView = zoomInFieldView
        }
        else
        {
            endFieldOfView = baseFieldOfView;
        }
        */

        while (elapsed < animTime)
        {
            float currentFieldOfView = Mathf.Lerp(startFieldOfView, endFieldOfView, elapsed / animTime);
            mainCam.fieldOfView = currentFieldOfView;
            elapsed += Time.deltaTime;
            yield return null;
        }

    }
}
