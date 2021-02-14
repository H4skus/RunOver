using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : MonoBehaviour
{
    public float speed = 5f;
    public Transform moveSpot;
    public GameObject Sword;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(Die());
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
        Instantiate(Sword, transform.position, Quaternion.identity);
    }
}
