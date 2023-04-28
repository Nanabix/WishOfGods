using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpwan : MonoBehaviour
{
    public Transform feetPosition;

   
    private void Awake()
    {
        // Find the SpawnPoint game object in the current scene
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("spawnpoint");
        if(spawnPoint != null)
        {
            Debug.Log("Found spawnpoint");
        }
        // If the SpawnPoint game object exists, set the player's position to its position
        if (spawnPoint != null)
        {
            feetPosition.parent.transform.position = spawnPoint.transform.position;
        }
    }
}
