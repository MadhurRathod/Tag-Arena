using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    public float PlayerSpeed = 5.0f;

    void Update()
    {
      if(photonView.IsMine)
        { float moveX = Input.GetAxis("Horizontal") * PlayerSpeed * Time.deltaTime;
            float moveZ = Input.GetAxis("Vertical") * PlayerSpeed * Time.deltaTime;
            transform.Translate(moveX, 0, moveZ);
        }
    }
}
