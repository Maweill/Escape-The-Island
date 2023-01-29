using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Factories;
using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [Inject]
    private GameFactory _gameFactory = null!;
    
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = _gameFactory.Player;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position;
    }
}
