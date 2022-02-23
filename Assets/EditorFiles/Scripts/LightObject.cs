using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightObject : MonoBehaviour
{
    public Light lightcomp;

    public Color color;
    public float intensity;
    public float range;
    public bool shadow;

    public void OnValidate()
    {
        if (gameObject.scene.name == null || gameObject.scene.name == gameObject.name || lightcomp == null) return;

        lightcomp.color = color;
        lightcomp.intensity = intensity * 10; //I don't know why but the shadows ingame are much brighter
        lightcomp.range = range;
        lightcomp.shadows = shadow ? LightShadows.Soft : LightShadows.None;
    }
}
