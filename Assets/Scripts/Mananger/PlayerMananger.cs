using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMananger : MonoBehaviour
{
    #region Singleton
    public static PlayerMananger instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
