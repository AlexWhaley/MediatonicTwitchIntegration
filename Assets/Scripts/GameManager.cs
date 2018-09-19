using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private List<PlayerController> _players;

    // Use this for initialization
    void Start ()
    {
        if (_players.Count > 0)
        {
            _players[0].InitialisePlayer(new PlayerConfig()
            {
                PlayerControls = new PlayerControls()
                {
                    UpKey = "w",
                    DownKey = "s",
                    RightKey = "d",
                    LeftKey = "a"
                },
                PlayerColor = Color.blue
            });
        }
    }
}
