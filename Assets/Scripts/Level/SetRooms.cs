using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRooms : MonoBehaviour
{

    public GameObject left;//0
    public GameObject right;//1
    public GameObject middlePoint;
    public GameObject[] rooms;
    public GameObject[] BoxsPos;
    public GameObject Box;
    float posx;
    float posy;
    float posz;
    // Start is called before the first frame update
    void Start()
    {
        BoxSet();
        RoomsSet();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void RoomsSet()
    {
        int roomType = Random.Range(0, 2);
        if (roomType == 0)
        {
            posx = middlePoint.transform.position.x;
            posy = middlePoint.transform.position.y;
            posz = middlePoint.transform.position.z;

            Instantiate(rooms[roomType], new Vector3(posx, posy, posz - 40), Quaternion.identity);
            GameObject.Destroy(right);
        }
        else if (roomType == 1)
        {
            posx = middlePoint.transform.position.x;
            posy = middlePoint.transform.position.y;
            posz = middlePoint.transform.position.z;

            Instantiate(rooms[roomType], new Vector3(posx, posy, posz + 40), Quaternion.identity);
            GameObject.Destroy(left);
        }
    }
    void BoxSet()
    {
        int Pos = Random.Range(0, 3);
        if (Pos==0)
        {
            Instantiate(Box, BoxsPos[Pos].transform.position, Quaternion.identity) ;
            GameObject.Destroy(BoxsPos[1]);
            GameObject.Destroy(BoxsPos[2]);
            GameObject.Destroy(BoxsPos[3]);
        }if (Pos==1)
        {
            Instantiate(Box, BoxsPos[Pos].transform.position, Quaternion.identity) ;
            GameObject.Destroy(BoxsPos[0]);
            GameObject.Destroy(BoxsPos[2]);
            GameObject.Destroy(BoxsPos[3]);
        }
        if (Pos==2)
        {
            Instantiate(Box, BoxsPos[Pos].transform.position, Quaternion.identity) ;
            GameObject.Destroy(BoxsPos[1]);
            GameObject.Destroy(BoxsPos[0]);
            GameObject.Destroy(BoxsPos[3]);
        }
        if (Pos==3)
        {
            Instantiate(Box, BoxsPos[Pos].transform.position, Quaternion.identity) ;
            GameObject.Destroy(BoxsPos[1]);
            GameObject.Destroy(BoxsPos[2]);
            GameObject.Destroy(BoxsPos[0]);
        }
    }
}
