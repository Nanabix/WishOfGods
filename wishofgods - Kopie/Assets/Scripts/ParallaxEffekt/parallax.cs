using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    private float lenght, startpos, posY;
    public GameObject cam;
    public float parallaxEffectX;
    public float parallaxEffectY;

    void Start()
    {
        if (!cam)
            cam = GameObject.FindGameObjectWithTag("MainCamera");
        //get position of layer
        startpos = transform.position.x;
        posY = transform.position.y;
        //lenght of background
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    
    void FixedUpdate()
    {
        
        float temp = (cam.transform.position.x * (1 - parallaxEffectX));
        //relative position of layer to camera
        float dist = (cam.transform.position.x * parallaxEffectX);
        float distY = (cam.transform.position.y * parallaxEffectY);

        //transform layer position
        //vector => gets new position from starting position and relative position inx and y, z is unchanged
        transform.position = new Vector3(startpos + dist, posY + distY , transform.position.z);
        //try to get endless backgrounds by repeating background, when Player gets close to end of Sprite
        if (temp > startpos+lenght) startpos += lenght;
        else if (temp <  startpos - lenght) startpos -= lenght;
    }
}
