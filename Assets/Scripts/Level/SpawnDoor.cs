using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoor : MonoBehaviour
{
    GameObject GameMaster;
    GameMaster gm;
    public Animation anim;
    public Timer timer;
    bool isUsed;
    public GameObject text1;
    public GameObject text2;
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
        if (!isUsed)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.Play();
                timer.isStarted = true;
                isUsed = true;
            }
        }
    }
}
