using UnityEngine;
using UnityEngine.UI;

public class RowGeneration : MonoBehaviour
{

    public GameObject Input;
    public bool Generate;
    public int inputvalue;
    public InputField InputField;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        Generate = false;
    }

    // Update is called once per frame
    void Update()
    {

        string inputText = new string (InputField.text);
        int InputInt = int.Parse(inputText);
        print(InputInt);

        inputvalue = InputInt;

        //for (int inputvalue = 0; inputvalue < 5; inputvalue++)
        //{

        //}


            Vector2 UpperRightCorner = new Vector2(-2 + 2f, -2 + 0.5f);
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
