using Unity.VisualScripting;
using UnityEngine;

public class LineCaster : MonoBehaviour
{
    public Vector2 Point1;
    public Vector2 Point2;

    public LayerMask hitLayers;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
     
       
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Linecast(Point1, Point2, hitLayers);
        if (hit)
        {
            print("Passedlined!");
        }
    }
}
