using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public GameObject PlayerPrefab;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();    
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to photon master server");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returncode , string message)
    {
        Debug.Log("Failed to join a random room creating a new room");
        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 20 });
    }
    
    public override void OnJoinedRoom ()
    {
        Debug.Log("Joined a room successfully");
        PhotonNetwork.Instantiate(PlayerPrefab.name, Vector3.zero, Quaternion.identity);
    }
}
