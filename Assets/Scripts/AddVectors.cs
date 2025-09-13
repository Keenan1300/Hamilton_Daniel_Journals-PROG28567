using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class AddVectors : MonoBehaviour
{
    public Transform redTransform;
    public Transform blueTransform;
    float magnitude;

    void Update()
    {
        // Exercise: Visualizing Vector Addition
        // Create a new Vector2 called "rPlusB" which adds rTransform's position to bTransform's position.​
        Vector2 rPlusB = redTransform.position + blueTransform.position;
        

        // When the B key is held down, draw a blue line from the origin to bTransform's position
        if (Input.GetKey(KeyCode.B))
        {
            Debug.DrawLine(Vector2.zero, redTransform.position, Color.blue);
        }

        // When the R key is held down, draw a red line from the origin to rTransform's position.​
        if (Input.GetKey(KeyCode.R))
        {
            Debug.DrawLine(Vector2.zero, blueTransform.position, Color.red);
        }

        // When the R and B keys are both held down, draw a magenta from the origin to rPlusB.​
        if (Input.GetKey(KeyCode.B) && Input.GetKey(KeyCode.R))
        {
            Debug.DrawLine(Vector2.zero, rPlusB, Color.magenta);
        }



        // Exercise: Calculating Magnitude

        // Calculate the magnitude of bPlusR using the mathematical formula for calculating the length of a vector – Pythagorean Theroem.​
        // Output the magnitude to the console using either Debug.Log or print.
        magnitude = Mathf.Sqrt(Mathf.Pow(rPlusB.x, 2) + Mathf.Pow(rPlusB.y, 2));

        print("My equation" + magnitude);
        print("Computer result" + rPlusB.magnitude);
        
    }
}

