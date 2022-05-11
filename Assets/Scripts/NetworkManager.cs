using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager instance { get; private set;}

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            gameObject.SetActive(false);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conexão Bem Sucedida");
    }

    public void CreateRoom(string roomName)
    {
        PhotonNetwork.CreateRoom(roomName);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void ChangeNick(string nickname)
    {
        PhotonNetwork.NickName = nickname;
    }

    public string GetPlayersList()
    {
        var list = "";
        foreach(var player in PhotonNetwork.PlayerList)
        {
            list += player.NickName + "\n";
        }
        return list;
    }

    public bool MasterClientRoom()
    {
        return PhotonNetwork.IsMasterClient;
    }

    public void ExitLobby()
    {
        PhotonNetwork.LeaveRoom();
    }

    [PunRPC]
    public void StartGame(string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }

}
