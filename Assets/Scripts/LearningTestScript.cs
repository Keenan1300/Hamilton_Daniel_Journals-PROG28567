using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class LearningTestScript : MonoBehaviour
{
    public float radius = 1.0f;
    public int numberofAngles = 6;
    public List<float> angles = new List<float>();

    //time
    public float lineDuration = 10.0f;
    private float elapsedtime = 0.0f;

    private int currentIndex = 0;
    private bool isRunning = false;

    public Vector3 cirlecenter = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numberofAngles; i++)
        {
            angles.Add(Random.value * 360f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        elapsedtime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) || elapsedtime > lineDuration)
        {
            currentIndex = (currentIndex + 1) % angles.Count; 
        }

        float angleinRad = angles[currentIndex] * Mathf.Deg2Rad;
        float y = Mathf.Sin(angleinRad);
        float x = Mathf.Cos(angleinRad);

        Vector3 endpoint= new Vector3(x, y, 0) * radius;

        Debug.DrawLine(cirlecenter, cirlecenter + endpoint, Color.green);

        
    }




}
