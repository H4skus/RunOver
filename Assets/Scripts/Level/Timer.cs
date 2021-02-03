using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{

    GameObject GameMaster;
    GameMaster gm;

    public float Count = 10f;
    public bool isStarted = false;

    private void Start()
    {
        GameMaster = GameObject.Find("GameMaster");
        gm = GameMaster.GetComponent<GameMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
        {
            Count -= Time.deltaTime;
            gm.Timer(Count.ToString());
            if (Count <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }

    }
}
