using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Material[] materials;//We can input the colors
    public Renderer rend; // Asks what Object to render

    private int index=1;// Initializes at 1, else we have to double click at the beginnig

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>(); //gives the functionality to the render.
        //rend.enabled = true;// Makes the renderd 3D object visible.
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if(materials.Length==0)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            index += 1;//when mouse presses down it increments to next index
            if(index==materials.Length+1)//To start over the colors when it reaches end
            {
                index = 1;
            }
            Debug.Log("Exmaple");

            //This sets the material color values inside the index.
            rend.sharedMaterial = materials[index - 1];
        }

    }
}
