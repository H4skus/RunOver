using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventText : MonoBehaviour
{
    public Text Writetext;
    public Text TimerText;
    public Text Magazine;
    public Text Reserve;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Timer(string text)
    {
        TimerText.text = text;
    }
    public void ShowText(string text)
    {
        gameObject.SetActive(true);
        Writetext.text = text;
        StartCoroutine(HideText());
    }
    IEnumerator HideText()
    {
        yield return new WaitForSeconds(2);
        Writetext.text = "";
    }

    public void MagazineSize(int number)
    {
        Magazine.text = number.ToString();
    }
    public void ReserveAmmo(int number)
    {
        Reserve.text = number.ToString() ;
    }
}
