using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemey : MonoBehaviour
{
    public Transform middle;
    public float x_pos;
    public float z_pos;
    public List<GameObject> Enemies = new List<GameObject>();
    public bool isTriggerd = false;
    public GameObject Enemy;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (!isTriggerd && other.tag == "Player")
        {
            Debug.Log("Enemies spawned");
            SpawnEnemy();
            isTriggerd = true;
        }
    }
    private void Update()
    {
        
    }
    public void SpawnEnemy()
    {
        int enemy = Random.Range(1,11);
        for (int i = 0; i < enemy; i++)
        {
            Enemies.Add(Enemy);
            float x_pos = Random.Range(0.4666667f, -0.4666667f);
            float z_pos = Random.Range(0.475f, -0.475f);
            Spawn(x_pos, z_pos, enemy);
            Debug.Log(i + " Enemy");
        }
    }
    public void Spawn(float x, float z, int enemy)
    {
            Instantiate(Enemy, new Vector3(middle.position.x + x, middle.position.y, middle.position.z + z), Quaternion.identity);
    }
}
