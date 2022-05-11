using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
public class LobbyMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Text _playersList;
    [SerializeField]
    private Button _startGame;

    [PunRPC]

    public void RefreshList()
    {
        _playersList.text = NetworkManager.instance.GetPlayersList();
        _startGame.interactable = NetworkManager.instance.MasterClientRoom();
    }


}
