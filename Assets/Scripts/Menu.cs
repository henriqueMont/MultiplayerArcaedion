using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Menu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private EnterMenu _enterMenu;
    [SerializeField]
    private LobbyMenu _lobbyMenu;

    private void Start() 
    {
        _enterMenu.gameObject.SetActive(false);
        _lobbyMenu.gameObject.SetActive(false);
    }

    public override void OnConnectedToMaster()
    {
        _enterMenu.gameObject.SetActive(true);
    }

    public override void OnJoinedRoom()
    {
        ChangeMenu(_lobbyMenu.gameObject);
        _lobbyMenu.photonView.RPC("RefreshList", RpcTarget.All);
    }

    public void ChangeMenu(GameObject menu)
    {
        _enterMenu.gameObject.SetActive(false);
        _lobbyMenu.gameObject.SetActive(false);

        menu.SetActive(true);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        _lobbyMenu.RefreshList();
    }

    public void ExitLobby()
    {
        NetworkManager.instance.ExitLobby();
        ChangeMenu(_enterMenu.gameObject);
    }

    public void StartGame(string sceneName)
    {
        NetworkManager.instance.photonView.RPC("StartGame", RpcTarget.All, sceneName);
    }
}
