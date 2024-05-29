using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public Text timerText;
    public Text itPlayerText;

    void Update()
    {
        if (TagMechanics.instance != null)
        {
            // Update the timer text 
            float remainingTime = Mathf.Ceil(TagMechanics.instance.timer);
            timerText.text = "Time: " + remainingTime.ToString();

            //Update the "It" player text
            if (TagMechanics.itPlayer != null)
            {
                itPlayerText.text = "It: " + TagMechanics.itPlayer.name;
            }
            else
            {
                itPlayerText.text = "It: None";
            }
        }
       
    }
}