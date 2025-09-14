using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class Pipeline : MonoBehaviour
{

    public Vector2 PointAlocation;
    public Vector2 PointBlocation;
    public Vector2 mousescreenPositionA;
    public Vector2 mousescreenPositionB;
    public Vector2 mousescreenPositionCurrent;

    public Camera main;
    public bool mouseisdown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mouseisdown = false;
    }

    // Update is called once per frame
    void Update()
    {



        if ((Input.GetMouseButtonDown(0)))
        {  
            Vector2 mousedown = Input.mousePosition;
            Vector2 mousescreenPositionA = Camera.main.ScreenToWorldPoint(mousedown);
            Vector2 PointAlocation = new Vector2(mousescreenPositionA.x, mousescreenPositionA.y);
            print(PointAlocation);
        }
       

           
        if ((Input.GetMouseButton(0)))
        {
            Vector2 mouseon = Input.mousePosition;
            Vector2 mousescreenPositionCurrent = Camera.main.ScreenToWorldPoint(mouseon);
            print(mousescreenPositionCurrent);

            mouseisdown = true;
        }
        else
        {
            mouseisdown = false; 
        }




        if ((Input.GetMouseButtonUp(0)))
        {
            Vector2 mouseup = Input.mousePosition;
            Vector2 mousescreenPositionB = Camera.main.ScreenToWorldPoint(mouseup);
            Vector2 PointBlocation = new Vector2(mousescreenPositionB.x, mousescreenPositionB.y);

        }



        if (mouseisdown == true)
        {

            Debug.DrawLine(PointAlocation, mousescreenPositionCurrent);

        }
        else
        {
            Debug.DrawLine(PointAlocation, PointBlocation);

        }

    }
}
