using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public GameObject StartPoint;
    CharacterController cc;
    public GameObject player;
    public InventoryObject RunInvetroy;
    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.Find("Player").GetComponent<CharacterController>();
        cc.enabled = false;
        player.transform.position = StartPoint.transform.position;
        //RunInvetroy.Container.Clear();
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.1f);
        cc.enabled = true;
    }
}
