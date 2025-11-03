using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public int ballSpawnCount = 100;
    public float ballSpawnDelay = 0.05f;
    public bool RandomColors = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    IEnumerator Start()
    {
      for(int i = 0; i < ballSpawnCount; i++)
      {

            GameObject ball = Instantiate(ballPrefab,transform.position,Quaternion.identity);
            Rigidbody2D Body2D = ball.GetComponent<Rigidbody2D>();
            Body2D.AddForce(Random.insideUnitCircle.normalized, ForceMode2D.Impulse);
            
            if(RandomColors)
            {
                ball.GetComponent<SpriteRenderer>().color=new Color(Random.value, Random.value, Random.value);
            }

            yield return new WaitForSeconds(ballSpawnDelay);
      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
