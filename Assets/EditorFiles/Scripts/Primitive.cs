using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Primitive : MonoBehaviour
{
    public PrimitiveType PrimitiveType;

    public Color color = Color.white;

    public void OnValidate()
    {
        if (gameObject.scene.name == null || gameObject.scene.name == gameObject.name) return;

        GetComponent<Renderer>().material.color = color;
    }
}
