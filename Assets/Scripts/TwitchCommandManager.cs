using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwitchCommandManager : MonoBehaviour
{
    public static TwitchCommandManager Instance { get; private set; }

    public delegate void CommandRegister(string command);
    public CommandRegister TwitchCommandRegister;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void InterpretTwitchMessage(string message)
    {
        TwitchCommandRegister(message);
    }
}
