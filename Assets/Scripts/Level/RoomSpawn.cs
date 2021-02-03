using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{
    public SetRooms setrooms;
    [SerializeField]
    public GameObject[] Spawns;
    public GameObject[] Rooms;
    public GameObject SafeZone;
    public bool[] spawnedRooms;
    public GameObject Finish;
    public Vector3 pos;
    public bool safeIsSpawned = false;

    public Vector3 SafePos;

    // Start is called before the first frame update
    void Start()
    {
        SpawnRooms();
        //StartCoroutine(SafeSpawnCheck());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*IEnumerator SafeSpawnCheck()
    {
        yield return new WaitForSeconds(10);
        if (!safeIsSpawned)
        {

        }
    }
    */

    void SpawnRooms()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        int max = Random.Range(5, 11);
        int finishPos = 0;
        for (int i = 0; i < max; i++)
        {
            int type = Random.Range(0, Rooms.Length);
            pos = new Vector3(pos.x + 30, pos.y, pos.z);
            Instantiate(Rooms[type],pos,Quaternion.identity);
            finishPos += 30;
        }
        finishPos += 30;
        pos = new Vector3(0 + finishPos, 0.5f, 0);
        pos = new Vector3(pos.x,pos.y,pos.z);
        Instantiate(Finish, pos, Quaternion.identity);

    }
    /*void TestSpawn()
    {
        int max = 2;
        
        Vector3 pos = new Vector3(0, 0.5f, 0);
        //Vector3 pos = new Vector3(0 + 52, 0.5f + 8f, 0 - 15);
        pos = new Vector3(pos.x + 40, pos.y, pos.z);
        Instantiate(Rooms[5], pos, Quaternion.identity);
    }
    */
}
