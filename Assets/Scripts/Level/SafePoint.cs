using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafePoint : MonoBehaviour
{
    RoomSpawn roomSpawn;
    // Start is called before the first frame update
    void Start()
    {
        roomSpawn = GameObject.Find("GameMaster").GetComponent<RoomSpawn>();
        int isSpawn = Random.Range(1,3);
        if (isSpawn == 2 && !roomSpawn.safeIsSpawned)
        {
            Instantiate(roomSpawn.SafeZone, transform.position, Quaternion.Euler(0,-90,0));
            roomSpawn.safeIsSpawned = true;
        }   
    }
}
