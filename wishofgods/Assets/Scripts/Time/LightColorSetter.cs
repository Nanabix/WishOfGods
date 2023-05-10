using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightColorSetter : MonoBehaviour, DayNightInterface
{
    public Gradient gradient;
    public UnityEngine.Rendering.Universal.Light2D[] lights;

    //get gradients on lights
    public void GetComponent()
    {
        lights = GetComponentsInChildren<UnityEngine.Rendering.Universal.Light2D>();
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
