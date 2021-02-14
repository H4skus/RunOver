using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slash : MonoBehaviour
{
    public Animator anim;
    public float TimeBeetweenAttack;
    public float currentlyTime;
    public GameObject Sword;
    private void Start()
    {
        currentlyTime = TimeBeetweenAttack;
    }

    private void Update()
    {
        currentlyTime += Time.deltaTime;
        if (PlayerPrefs.GetInt("accesForSword") == 1 && Input.GetKeyDown(KeyCode.F) && currentlyTime >= TimeBeetweenAttack)
        {
            Sword.SetActive(true);
            anim.SetBool("Attack", true);
            StartCoroutine(SetActive(anim.GetCurrentAnimatorStateInfo(0).length));
            currentlyTime = 0;
        }
    }
    IEnumerator SetActive(float delay)
    {
        yield return new WaitForSeconds(delay-.75f);
        anim.SetBool("Attack", false);
        Sword.SetActive(false);
    }
}
