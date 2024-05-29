using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class TagMechanics : MonoBehaviourPunCallbacks
{
    public static TagMechanics instance;
    public static GameObject itPlayer;
    public float gameTime = 120f; // 2 minutes
    public float timer;

    void Awake()
    {
        // Implementing the singleton pattern
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        timer = gameTime;
        if (PhotonNetwork.IsMasterClient)
        {
            ChooseItPlayer();
        }
    }

    
    void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                EndGame();
            }
        }
    }

    void ChooseItPlayer()
    {
        int randomIndex = Random.Range(0, PhotonNetwork.PlayerList.Length);
        Photon.Realtime.Player randomPlayer = PhotonNetwork.PlayerList[randomIndex];
        PhotonView randomPlayerPhotonView = PhotonView.Find(randomPlayer.ActorNumber);
        photonView.RPC("SetItPlayer", RpcTarget.AllBuffered, randomPlayerPhotonView.ViewID);
    }

    [PunRPC]
    void SetItPlayer(int playerViewID)
    {
        itPlayer = PhotonView.Find(playerViewID).gameObject;
        itPlayer.GetComponent<Renderer>().material.color = Color.red; // Mark "It" player with red color
    }

    void EndGame()
    {
        // Logic to end the game and declare the results
        PhotonNetwork.LoadLevel("EndScene");
    }
}

public class PlayerTag : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (TagMechanics.itPlayer == gameObject && collision.gameObject.CompareTag("Player"))
        {
            TagMechanics.itPlayer.GetComponent<Renderer>().material.color = Color.white; // Remove "It" status
            TagMechanics.itPlayer = collision.gameObject;
            TagMechanics.itPlayer.GetComponent<Renderer>().material.color = Color.red; // New "It" player
        }
    }
}





