using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class DrawVectors : MonoBehaviour
{
    public Vector2 dVector;
    public Vector2 eVector;

    void Update()
    {
        // Create two Vector2 variables, "dVector" and "eVector"
        // Set their values to dVector: (0, 1) and eVector: (3, -2)

        Vector2 dVector = new Vector2(0f, 1f);
        Vector2 eVector = new Vector2(3f, -2f);



        // Use Debug.DrawLine to draw a yellow vector starting at the origin and ending at dVector.
        // Use Debug.DrawLine to draw a grey vector starting at the origin and ending at eVector.
        Debug.DrawLine(Vector2.zero, dVector,Color.yellow);
        Debug.DrawLine(Vector2.zero, eVector, Color.grey);
        
    }
}
