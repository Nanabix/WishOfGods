using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;


    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;

    private bool playerInrange;

    private void Awake()
    {
        playerInrange = false;
        visualCue.SetActive(false);
    }

    //only set visual cue active when player is in range and no dialogue is playing
    private void Update()
    {
        if (playerInrange && !DialogueManager.GetInstance().dialogueIsPlaying)
        {
            visualCue.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            }
        } else
        {
            visualCue.SetActive(false);
        }
    }

    //check if player is in range
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") { playerInrange = true; }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { playerInrange = false; }
    }
}
