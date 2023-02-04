using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject playerPrefab;
    private GameObject playerInstance;

    void Start()
    {
        SpawnPlayer();
    }

    void Update()
    {
        if (playerInstance == null)
        {
            SpawnPlayer();
        }
    }

    void SpawnPlayer()
    {
        playerInstance = Instantiate(playerPrefab, transform.position, transform.rotation);
    }
}
