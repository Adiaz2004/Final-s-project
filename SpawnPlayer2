using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnPlayer2 : MonoBehaviour
{
    public GameObject playerPrefab;

    void Start()
    {
        SpawnPlayerAtPoint();
    }

    void SpawnPlayerAtPoint()
    {
        if (playerPrefab != null)
        {
            Instantiate(playerPrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("PlayerPrefab not set in the SpawnPlayer script!");
        }
    }
}
