using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScripts : MonoBehaviour
{
    [Header("Next Level")]
    public string levelToLoad;
    bool doorActive = false;
    public Vector2 playerPosition;
    public VectorValue playerStorage;

    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;
   

    private void Awake()
    {
        //cue always non visible
        visualCue.SetActive(false);
    }
    void Update()
    {
        
        if (Input.GetKey(KeyCode.E) && doorActive)
        {
            //save players position
            playerStorage.initialValue = playerPosition;
            //change scene
            SceneManager.LoadScene(levelToLoad);
 
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //door active, when player in range
            visualCue.SetActive(true);
            Debug.Log("Door active");
            //set cue active
            doorActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //door inactive, when player is not in range
            visualCue.SetActive(false);
            Debug.Log("Door inactive");
            doorActive = false;
        }
    }
}
