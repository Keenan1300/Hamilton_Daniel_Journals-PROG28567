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

    public float BombTrailSpacing;
    public int NumberOfTrailBombs;

    public float inDistance;

    public float distanceratio;

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

            SpawnBombAtOffset(new Vector3(0, 1));

        }


        //SpawnCornerBomb
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SpawnBombAtRandomCorner(inDistance);


        }

        //Warp ship
        if (Input.GetKeyDown(KeyCode.W))
        {
            Warptheship(enemyTransform, distanceratio);


        }
    }

    //Spawn Bomb at offset
    private void SpawnBombAtOffset(Vector3 inOffset)
    {
        Vector3 SpawnPosition = transform.position + inOffset;
        Instantiate(bombPrefab, SpawnPosition, Quaternion.identity);
    }

    //Bomb trail task
    public void SpawnBombTrail(float BombTrailSpacing, int NumberOfTrailBombs)
    {

        float Spawnedbombs = 1;

        for (int i = 0; i < NumberOfTrailBombs; i++)
        {
            Vector2 PlayerPosition = transform.position;
            Vector2 Bombposition = new Vector2(PlayerPosition.x, PlayerPosition.y + BombTrailSpacing * Spawnedbombs);
            Instantiate(bombPrefab, Bombposition, Quaternion.identity);
            Spawnedbombs += 1;
        }
    }



    //Corner Bomb Exercise start

    public void SpawnBombAtRandomCorner(float inDistance)
    {

        //choose random number from 1 to 4
        int RandomCorner = Random.Range(0, 4);

        Vector2 Playerlocation = transform.position;

        //Setup what "Corners" mean
        Vector2 BottomL = Playerlocation + new Vector2(-1, -1);
        Vector2 BottomR = Playerlocation + new Vector2(1, -1);
        Vector2 TopR = Playerlocation + new Vector2(1, 1);
        Vector2 TopL = Playerlocation + new Vector2(-1, 1);


        //Roll for what corner is chosen
        if (RandomCorner == 1)
        {
            Vector2 NormalizeBottomL = BottomL.normalized;
            Vector2 BombLocation = NormalizeBottomL * inDistance;
            Instantiate(bombPrefab, BombLocation, Quaternion.identity);
        }

        if (RandomCorner == 2)
        {
            Vector2 NormalizeBottomR = BottomR.normalized;
            Vector2 BombLocation = NormalizeBottomR * inDistance;
            Instantiate(bombPrefab, BombLocation, Quaternion.identity);
        }
        if (RandomCorner == 3)
        {
            Vector2 NormalizeTopL = TopL.normalized;
            Vector2 BombLocation = NormalizeTopL * inDistance;
            Instantiate(bombPrefab, BombLocation, Quaternion.identity);
        }
        if (RandomCorner == 4)
        {
            Vector2 NormalizeTopR = TopR.normalized;
            Vector2 BombLocation = NormalizeTopR * inDistance;
            Instantiate(bombPrefab, BombLocation, Quaternion.identity);
        }
    }
    
    //Function to warp ship in target dirction
    public void Warptheship(Transform enemytransform, float distanceratio) 
    {
        if(distanceratio > 1)
        {
          distanceratio = 1;
        }

        Vector2 playerposition = transform.position;
        Vector2 Enemylocation = enemyTransform.position;

        Vector2 interpolatedposition = Vector2.Lerp(playerposition, Enemylocation, distanceratio);

        transform.position = interpolatedposition;


    }

    
}
