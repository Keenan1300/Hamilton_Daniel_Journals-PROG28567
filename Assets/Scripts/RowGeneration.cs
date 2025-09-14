using UnityEngine;

public class RowGeneration : MonoBehaviour
{

    public GameObject InputField;
    public bool Generate;
    public int inputvalue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Generate = false;
    }

    // Update is called once per frame
    void Update()
    {
        //inputvalue = InputField.

            //for (int inputvalue = 0; inputvalue < 5; inputvalue++)
            //{

            //}


            Vector2 UpperRightCorner = new Vector2(-2 + inputvalue, -2 + 0.5f);
            Vector2 UpperLeftCorner = new Vector2(-2 - 0.5f, -2 + 0.5f);
            Vector2 LowerRightCorner = new Vector2(UpperRightCorner.x, UpperRightCorner.y - 1f);
            Vector2 LowerLeftCorner = new Vector2(UpperLeftCorner.x, UpperLeftCorner.y - 1f);

        if (Generate)
        {
            //draw square - Horizontal
            Debug.DrawLine(UpperLeftCorner, UpperRightCorner);
            Debug.DrawLine(LowerLeftCorner, LowerRightCorner);


            //Vertical - no middle lines
            Debug.DrawLine(UpperRightCorner, LowerRightCorner);
            Debug.DrawLine(UpperLeftCorner, LowerLeftCorner);
        
        }
    }

    public void DrawSquares()
    {
        Generate = true;


    }
}
