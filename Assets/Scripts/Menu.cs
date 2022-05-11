using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Menu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private EnterMenu enterMenu;

    private void Start() 
    {
        enterMenu.gameObject.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        enterMenu.gameObject.SetActive(true);
    }
}
