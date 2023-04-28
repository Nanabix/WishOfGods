using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


//not in use
//automatically follow player when loading
public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    public Transform tFollowTarget;
    private CinemachineVirtualCamera vcam;

    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }
        tFollowTarget = player.transform;
        vcam.LookAt = tFollowTarget;
        vcam.Follow = tFollowTarget;
    }

    
}
