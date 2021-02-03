using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    GameObject GameMaster;
    GameMaster gm;

    private void Start()
    {
        GameMaster = GameObject.Find("GameMaster");
        gm = GameMaster.GetComponent<GameMaster>();
    }

    private void OnTriggerEnter(Collider other)
    {
        gm.CallText("Press E to open");
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PlayerPrefs.GetInt("Keys") >= 1)
            {
                PlayerPrefs.SetInt("Keys", PlayerPrefs.GetInt("Keys") - 1);
                gm.CallText("Unlocked");
                GameObject.Destroy(gameObject);
            }
            else
            {
                gm.CallText("Ya dont have enough Key");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {

    }

}
