using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color[] colors;
    public SpriteRenderer mesh;

    public static ColorChange instance;

     private void Awake()
    {
        instance = this;
        mesh = GetComponent<SpriteRenderer>();
        
    }

    public void ChangeColor(int index)
    {
        Color color = colors[index];
        mesh.color = color;
    }
}
