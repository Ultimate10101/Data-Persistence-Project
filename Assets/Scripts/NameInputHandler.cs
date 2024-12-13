using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NameInputHandler : MonoBehaviour
{
    public static NameInputHandler Instance;
    
    public string PlayerName { get; private set; }

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        PlayerName = "";
    }

    public void NameGrabber(string playerName)
    {
        PlayerName = playerName;
    }
}
