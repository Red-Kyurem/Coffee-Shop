using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public Color[] colors;
    public Renderer mesh;

    public static ColorChange instance;

    public int index;
     private void Awake()
    {
        instance = this;
        mesh = GetComponent<Renderer>();
        
    }

    public void SetStartColor(bool darkFirst)
    {
        if (darkFirst)
        {
            index = 0;
        }
        else
        {
            index = 3;
        }

        Color color = colors[index];
        mesh.material.color = color; 
    }


    public void ChangeColor(bool goingup)
    {
            if (goingup)
            {
                index++;
            }

            else
            {
                index--;
            }
       

        Color color = colors[index];
        mesh.material.color = color;
    }


    public void ResetIndex()
    {
        index = 0;
    }
}
