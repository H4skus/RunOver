using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnShow : MonoBehaviour
{
    public GameObject text;
    private void OnTriggerEnter(Collider other)
    {
        text.SetActive(false);
    }
}
