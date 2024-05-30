using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; 

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.Instantiate("Player", new Vector3(Random.Range(-50, 50), 5f, Random.Range(-30, 30)), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
