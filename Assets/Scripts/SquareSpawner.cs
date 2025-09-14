using UnityEngine;

public class SquareSpawner : MonoBehaviour
{
    Vector2 mousefollowx;
    Vector2 mousefollowy;
    Vector2 mouse;

    Vector2 MouseLowerRightCorner;
    Vector2 MouseUpperLeftCorner;
    Vector2 MouseLowerLeftCorner;
    Vector2 MouseUpperRightCorner;

    public Camera cam;

     
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        //Task1 a- Draw Squares on mouse down
        Vector2 mouse = Input.mousePosition;
        Vector2 mousescreenPosition = Camera.main.ScreenToWorldPoint(mouse);


        //Square cornerlocation
        Vector2 MouseUpperRightCorner = new Vector2(mousescreenPosition.x + 0.5f + Input.mouseScrollDelta.y, mousescreenPosition.y + 0.5f + Input.mouseScrollDelta.y);
        Vector2 MouseUpperLeftCorner = new Vector2(mousescreenPosition.x - 0.5f - Input.mouseScrollDelta.y, mousescreenPosition.y + 0.5f + Input.mouseScrollDelta.y);
        Vector2 MouseLowerLeftCorner = new Vector2(mousescreenPosition.x - 0.5f - Input.mouseScrollDelta.y, mousescreenPosition.y - 0.5f - Input.mouseScrollDelta.y);
        Vector2 MouseLowerRightCorner = new Vector2(mousescreenPosition.x + 0.5f + Input.mouseScrollDelta.y, mousescreenPosition.y - 0.5f - Input.mouseScrollDelta.y);


        //Detect mouse
        if ((Input.GetMouseButtonDown(0)))
        {
            Debug.DrawLine(MouseUpperRightCorner, MouseUpperLeftCorner);
            Debug.DrawLine(MouseLowerLeftCorner, MouseLowerRightCorner);
            Debug.DrawLine(MouseLowerLeftCorner, MouseUpperLeftCorner);
            Debug.DrawLine(MouseLowerRightCorner, MouseUpperRightCorner);

        }

        //Task2 b - Draw square under mouse

        //Define Transparent White
        Color SemiTransparentWhite = new Color(255f, 255f, 255f, 0.5f);

        Vector2 CursorUpperRightCorner = new Vector2(mousescreenPosition.x + 1f + Input.mouseScrollDelta.y, mousescreenPosition.y + 1f + Input.mouseScrollDelta.y);
        Vector2 CursorUpperLeftCorner = new Vector2(mousescreenPosition.x - 1f - Input.mouseScrollDelta.y, mousescreenPosition.y + 1f + Input.mouseScrollDelta.y);
        Vector2 CursorLowerLeftCorner = new Vector2(mousescreenPosition.x - 1f - Input.mouseScrollDelta.y, mousescreenPosition.y - 1f - Input.mouseScrollDelta.y);
        Vector2 CursorLowerRightCorner = new Vector2(mousescreenPosition.x + 1f + Input.mouseScrollDelta.y, mousescreenPosition.y - 1f - Input.mouseScrollDelta.y);

        Debug.DrawLine(MouseUpperRightCorner, MouseUpperLeftCorner,SemiTransparentWhite);
        Debug.DrawLine(MouseLowerLeftCorner, MouseLowerRightCorner,SemiTransparentWhite);
        Debug.DrawLine(MouseLowerLeftCorner, MouseUpperLeftCorner,SemiTransparentWhite);
        Debug.DrawLine(MouseLowerRightCorner, MouseUpperRightCorner,SemiTransparentWhite);
    }
}
