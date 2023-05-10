using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightColorSetter : MonoBehaviour, DayNightInterface
{
    public Gradient gradient;
    public Light2D[] lights;

    //get gradients on lights
    public void GetComponent()
    {
        lights = GetComponentsInChildren<Light2D>();
    }

    //set color of light based on time
    public void SetParameter(float time)
    {
        foreach(var light in lights)
        {
            light.color = gradient.Evaluate(time);
        }
    }
}
