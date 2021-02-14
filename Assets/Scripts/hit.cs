using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("hitted" + other.tag);
            other.GetComponent<EnemyController>().TakeDamage(20);
        }
        if (other.gameObject.tag == "Box")
        {
            Debug.Log("hitted" + other.tag);
            other.GetComponent<DestroyableBox>().TakeDamage(20);
        }
    }
}
