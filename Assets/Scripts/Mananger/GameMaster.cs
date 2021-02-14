using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public PlayerStats playerStats;
    EventText eventText;
    // Start is called before the first frame update
    void Start()
    {
        eventText = GameObject.Find("Ui").GetComponent<EventText>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerStats.stats.health <= 0)
        {
            Restart();
        }
    }
    public void Timer(string text)
    {
        eventText.Timer(text);
    }
    public void CallText(string text)
    {
        eventText.ShowText(text);
    }
    public void PlayerGetDmg(int amount)
    {
        //playerStats.health -= amount;
    }
    public void Restart()
    {
        Time.timeScale = 0.2f;
        CallText("Ya dead!");
        Invoke("Death", 1);
    }
    void Death()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
