using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TeamNames : MonoBehaviour
{
    public Text blueTeam;
    public Text redTeam;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (blueTeam.text.Length >= 3) {
            PlayerPrefs.SetString("BlueName", blueTeam.text.ToUpper().Substring(0, 3));
        }
        else
        {
            PlayerPrefs.SetString("BlueName", blueTeam.text.ToUpper());
        }
        if (redTeam.text.Length >= 3)
        {
            PlayerPrefs.SetString("RedName", redTeam.text.ToUpper().Substring(0, 3));
        }
        else
        {
            PlayerPrefs.SetString("BedName", redTeam.text.ToUpper());
        }
    }
}