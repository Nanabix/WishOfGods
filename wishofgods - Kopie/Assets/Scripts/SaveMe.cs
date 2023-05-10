using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveMe : MonoBehaviour
{   [HideInInspector]
    public string objectID;

    private void Awake()
    {
        objectID = name + transform.position.ToString();
    }
    private void Start()
    {
        for(int i = 0; i < Object.FindObjectsOfType<SaveMe>().Length; i++)
        {
            if (Object.FindObjectsOfType<SaveMe>()[i] != this)
            {
                if (Object.FindObjectsOfType<SaveMe>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
            
        }
        
        DontDestroyOnLoad(gameObject);
    }
    private void Update()
    {
        
    }
    /*
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (this.gameObject != null)
        {
            // Check if the game object is already in the scene
            GameObject[] objs = scene.GetRootGameObjects();
            foreach (GameObject obj in objs)
            {
                if (obj == this.gameObject)
                {
                    // Destroy the duplicate game object
                    Destroy(this.gameObject);
                    return;
                }
            }
        }
    }*/
}
