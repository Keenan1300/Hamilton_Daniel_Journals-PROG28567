using UnityEngine;

public class BallTransformer : MonoBehaviour
{

    public GameObject Player;
    public GameObject Ball;
    bool ObjectSwitch = true;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ObjectSwitch = true;
        
    }

    // Update is called once per frame
    void Update()
    {


        if (ObjectSwitch)
        {
            Ball.SetActive(false);
            Player.SetActive(true);
            Ball.transform.position = Player.transform.position;
        }
        else
        {
            Ball.SetActive(true);
            Player.SetActive(false);
            Player.transform.position = Ball.transform.position;
            Vector3 Bpos = Ball.transform.position;
            Bpos.x += Input.GetAxisRaw("Horizontal") * 0.01f;
            Ball.transform.position = Bpos;

        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (ObjectSwitch)
            {
                ObjectSwitch = false;
            }
            else
            {
                ObjectSwitch = true;
            }
        }
    }
}

