using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterMenu : MonoBehaviour
{
    [SerializeField]
    private Text _playerName;
    [SerializeField]
    private Text _roomName;

    public void CreateRoom()
    {
        NetworkManager.instance.ChangeNick(_playerName.text);
        NetworkManager.instance.CreateRoom(_roomName.text);
    }
    public void JoinRoom()
    {
        NetworkManager.instance.ChangeNick(_playerName.text);
        NetworkManager.instance.JoinRoom(_roomName.text);
    }
}
