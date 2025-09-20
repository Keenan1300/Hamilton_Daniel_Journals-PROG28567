using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public List<Transform> asteroidTransforms;


    //Variables
    public float BombSpacing;
    public int NumberOfBombs;

    // Update is called once per frame
    void Update()
    {
        //Instantiate bomb at inOffset
        if (Input.GetKeyDown(KeyCode.T))
        {

            SpawnBombTrail(BombSpacing, NumberOfBombs);
        }


        //Instantiate bomb at inOffset
        if (Input.GetKey(KeyCode.B))
        {

            SpawnBombAtOffset(new Vector3(0,1));

        }
    }
        

private void SpawnBombAtOffset(Vector3 inOffset)
        {
            Vector3 SpawnPosition = transform.position + inOffset;
            Instantiate(bombPrefab, SpawnPosition, Quaternion.identity);
        }

public void SpawnBombTrail(float BombSpacing, int NumberOfBombs) 
{      
        
        float Spawnedbombs = 1;

    for (int i = 0; i < NumberOfBombs; i++) 
       {
            Vector2 PlayerPosition = transform.position;
            Vector2 Bombposition = new Vector2(PlayerPosition.x, PlayerPosition.y + BombSpacing * Spawnedbombs);
            Instantiate(bombPrefab, Bombposition, Quaternion.identity);
            Spawnedbombs += 1; 
     }
}
    

   
}
