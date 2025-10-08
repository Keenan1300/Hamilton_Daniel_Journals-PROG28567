using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Transform enemyTransform;
    public GameObject bombPrefab;
    public GameObject UpgradePrefab;

    public Asteroid CaughtAsteroid;

    public UnityEvent Magnetize;

    public List<Transform> asteroidTransforms;

    public List<GameObject> Asteroids;


    //force field
    public float radius = 1.0f;
    public int circlePoints = 6;
    public List<float> angles = new List<float>();

    //Add separate list so powerups work independently of shield
    public List<float> PowerUps = new List<float>();

    //PowerUps
    public int numberOfPowerups = 3;
    public float Powerradius = 1.0f;

    //time
    public float lineDuration = 10.0f;
    private float elapsedtime = 0.0f;

    private int currentIndex = 0;
    private int currentIndex2 = 1;
    private bool isRunning = false;



    //Variables
    public float BombSpacing;
    public int NumberOfBombs;

    public float BombTrailSpacing;
    public int NumberOfTrailBombs;

    public float inDistance;

    public float distanceratio;

    //Rotation Dynamics
    float x = 0;
    float y = 0;


    //detector
    public float Maxrange;

    //velocity
    private Vector3 velocity;


    //movement
    public float MaxSpeed = 3f;
    public float minspeed = 1f;
    public float Accelerationtime = 0.5f;

    

    void Start()
    {
        //setup variables
        currentIndex = 0;

        //calculate vertices
        for (int i = 0; i < circlePoints + 1; i++)
        {
            float floatconvert = i;
            angles.Add(floatconvert / circlePoints * 360f);
        }

       

        //Draw PowerUps
        SpawnPowerups(Powerradius, numberOfPowerups);
    }

    // Update is called once per frame
    void Update()
    {
        

        //draw cirlce
        EnemyRadar(radius, circlePoints);


        //player move left
        PlayerMovement();


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


        //Asteroid Detector
        if (Input.GetKey(KeyCode.Z))
        {
            Detector(Maxrange, asteroidTransforms);
        }

        //Asteroid Magnet
        if (Input.GetKey(KeyCode.M))
        {
            Magnet(Maxrange, Asteroids);
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
        if (distanceratio > 1)
        {
            distanceratio = 1;
        }

        Vector2 playerposition = transform.position;
        Vector2 Enemylocation = enemyTransform.position;

        Vector2 interpolatedposition = Vector2.Lerp(playerposition, Enemylocation, distanceratio);

        transform.position = interpolatedposition;


    }

    //detector functionality
    public void Detector(float Maxrange, List<Transform> asteroidTransforms)
    {
        //setup player spot
        Vector3 playerpos = transform.position;

        //Find out where a particular asteroid is
        for (int i = 0; i < asteroidTransforms.Count; i++)
        {
            Transform Asteroid = asteroidTransforms[i];
            Vector3 AsteroidPosition = Asteroid.position;

            float PlayerToAsteroidDist = Vector3.Distance(AsteroidPosition, playerpos);
            Vector3 Asteroidnorm = AsteroidPosition.normalized;
            float AstroidMag = AsteroidPosition.magnitude;

            //print("the length of asteroid is" + AstroidMag);

            if (AstroidMag < Maxrange)
            {
                Debug.DrawLine(playerpos, AsteroidPosition, Color.green);
            }
          
        }

    }

    public void PlayerMovement() 
    {

        //deceleration
        velocity -= velocity * Time.deltaTime * 2;

        float accelerationRate = MaxSpeed / Accelerationtime;
        Vector2 playerpos = transform.position;

        if (playerpos.x < 20 && playerpos.y < 20 && playerpos.x > -20 && playerpos.y > -20)
        {


            if (Input.GetKey(KeyCode.LeftArrow))
            {
                velocity += accelerationRate * Time.deltaTime * Vector3.left;
            }

            if (Input.GetKey(KeyCode.RightArrow))
            {
                velocity += accelerationRate * Time.deltaTime * Vector3.right;
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                velocity += accelerationRate * Time.deltaTime * Vector3.up;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                velocity += accelerationRate * Time.deltaTime * Vector3.down;


            }

        }
        else
        {
            playerpos = new Vector2(playerpos.x / 2, playerpos.y / 2);
            playerpos.Normalize();
        }






        if (playerpos != Vector2.zero)
        {

            //reset x and y
            x = 0; y = 0;

            //Input Detection
            if (Input.GetKey(KeyCode.LeftArrow)) x = 1;
            if (Input.GetKey(KeyCode.RightArrow)) x = -1;

            if (Input.GetKey(KeyCode.UpArrow)) y = 1;
            if (Input.GetKey(KeyCode.DownArrow)) y = -1;

            //calculate direction
            Vector3 moveDir = new Vector3(x, y, 0);
            moveDir.Normalize();

            //calculate angle
            float targetAngle = Mathf.Atan2(moveDir.x, moveDir.y) * Mathf.Rad2Deg;

            // Create target rotation
            Quaternion targetRotation = Quaternion.Euler(0f, targetAngle, 0f);

            // Smoothly rotate toward the snapped direction
            transform.rotation = Quaternion.AngleAxis(targetAngle, Vector3.forward);


        }
       






        //velocity wont exceed this value.
        velocity = Vector3.ClampMagnitude(velocity,MaxSpeed);

        transform.position += velocity * Time.deltaTime;
        
    }

    public void EnemyRadar(float radius, int circlePoints)
    {
        Vector3 Playerpos = transform.position;
        Vector3 EnemyPos = enemyTransform.position;

        //Draw force field
        currentIndex = (currentIndex + 1) % angles.Count;
        currentIndex2 = (currentIndex2 + 1) % angles.Count;



        float PointA = angles[currentIndex] * Mathf.Deg2Rad;

        float PointB = angles[currentIndex2] * Mathf.Deg2Rad;


        //Find vector for point A
        //find y
        float Ay = Mathf.Sin(PointA);

        //find x 
        float Ax = Mathf.Cos(PointA);



        //Find vector for point B
        //find y
        float By = Mathf.Sin(PointB);

        //find x
        float Bx = Mathf.Cos(PointB);


        //A spot used to be called Point
        Vector3 PointASpot = new Vector3(Ax, Ay, 0) * radius;

        //B spot is experimental
        Vector3 PointBSpot = new Vector3(Bx, By, 0) * radius;


        Vector3 PlayerEnemyDist = EnemyPos - Playerpos;
        float PlayerEnemyMag = PlayerEnemyDist.magnitude;

        if (PlayerEnemyMag > radius)
        {
            Debug.DrawLine(Playerpos + PointASpot, Playerpos + PointBSpot, Color.green);
        }
        else
        {
            Debug.DrawLine(Playerpos + PointASpot, Playerpos + PointBSpot, Color.red);
        }


    }


    public void SpawnPowerups(float Powerradius, int numberOfPowerups)
    {


        //calculate vertices
        for (int i = 0; i < numberOfPowerups + 1; i++)
        {
            float floatconvert = i;
            PowerUps.Add(floatconvert / numberOfPowerups * 360f);
        }

        //spawn bombs
        for (int i = 0; i < numberOfPowerups + 1; i++)
        {
            currentIndex = (currentIndex + 1) % PowerUps.Count;
            float PointA = PowerUps[currentIndex] * Mathf.Deg2Rad;



            //Find vector for point A
            //find y
            float Ay = Mathf.Sin(PointA);

            //find x 
            float Ax = Mathf.Cos(PointA);


            //A spot used to be called Point
            Vector3 PointASpot = new Vector3(Ax, Ay, 0) * Powerradius;
            Vector3 pos = transform.position;

            Instantiate(UpgradePrefab, PointASpot + pos, Quaternion.identity);

        }


    


       

  


    }


    //Magnet Pull functionality
    public void Magnet(float Maxrange, List<GameObject> Asteroids)
    {
        //setup player spot
        Vector3 playerpos = transform.position;

        //Find out where a particular asteroid is
        for (int i = 0; i < Asteroids.Count; i++)
        {
            Transform Asteroid = Asteroids[i].transform;
            Vector3 AsteroidPosition = Asteroid.position;

            float PlayerToAsteroidDist = Vector3.Distance(AsteroidPosition, playerpos);
            Vector3 Asteroidnorm = AsteroidPosition.normalized;
            float AstroidMag = AsteroidPosition.magnitude;

            GameObject CaughtAsteroid = Asteroids[i];
            Asteroid ScriptAsteroid = Asteroids[i].GetComponent<Asteroid>();


            if (AstroidMag < Maxrange)
            {

                ScriptAsteroid.magnetize();
                print("should magnetize!!");
            }
            else
            {
                print("no mag");
            }

        }

    }



}