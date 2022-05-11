using System.Collections;
using System.Collections.Generic;
using Arcaedion.Multiplayer;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager instance {get; private set;}
    [SerializeField]
    private string _localizationPrefab;
    [SerializeField]
    private Transform[] _spawns;

    private int _playersInGame = 0;
    private List<PlayerController> _players;
    public List<PlayerController> Players {get => _players; private set => _players = value;}


    public void Awake()
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
        photonView.RPC("AddPlayer", RpcTarget.AllBuffered);
        _players = new List<PlayerController>();
    }

    [PunRPC]
    private void AddPlayer()
    {
        _playersInGame++;
        if(_playersInGame == PhotonNetwork.PlayerList.Length)
        {
            CreatePlayer();
        }
    }

    private void CreatePlayer()
    {
        var playerObject = PhotonNetwork.Instantiate(_localizationPrefab, _spawns[Random.Range(0, _spawns.Length)].position, Quaternion.identity);
        var player = playerObject.GetComponent<PlayerController>();

        player.photonView.RPC("Initialize", RpcTarget.All, PhotonNetwork.LocalPlayer);
    }
}
