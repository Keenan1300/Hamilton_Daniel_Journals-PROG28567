using UnityEngine;

public class LearningTestScript : MonoBehaviour
{

    int a;
    int b;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(NormalizingVector(new Vector2(3, 4)));
        Debug.Log(NormalizingVector(new Vector2(-3, 2)));
        Debug.Log(NormalizingVector(new Vector2(1.5f, -3.5f)));
    }

    // Update is called once per frame
    void Update()
    {
      

        
    }

    public Vector2 NormalizingVector(Vector2 Input)
    {
        float magnitude = Input.magnitude;
        Vector2 NormalizedVec = new Vector2 (Input.x/ magnitude,Input.y/magnitude);
        return NormalizedVec;
    }



}
