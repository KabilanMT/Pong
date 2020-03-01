using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    public static float Speed;
    public double SpeedIncrease;
    public float DirectionX;
    public float DirectionZ;
    public string updateMovement;
    public Rigidbody rb;
    public Vector3 Pos;
    public bool instantiateInWorldSpace;
    public static float Player1Point = 0;
    public static float Player2Point = 0;
    public static float ballXPosition;
    public static bool canMove;
    public static string winner = null;



    // Use this for initialization

    void Start () {
        Speed = 10f;
        rb = GetComponent < Rigidbody >();
        rb.freezeRotation = true;
        Pos = new Vector3(1, 1, 0);
        instantiateInWorldSpace = true;
        SpeedIncrease = 10;
        StartCoroutine(waitThreeSeconds());

    }
	
	// Update is called once per frame
	void Update () {

        //used to keep track of the balls current position for the ai
        ballXPosition = transform.position.x;

        //checks to see if game has ended
        if (Player1Point < 7 && Player2Point < 7)
        {
            Vector3 position = this.transform.position;

            //tells the ball how to bounce depending on the situation
            if (transform.position.x < 5)
            {
                if (updateMovement == "Initial")
                {
                    transform.Translate(new Vector3(DirectionX, 0, DirectionZ) * Time.deltaTime * Speed);
                    canMove = true;
                }
                else if (updateMovement == "BouncedoffZ" || updateMovement == "BouncedoffPlayer")
                {

                    transform.Translate(new Vector3(DirectionX, 0, DirectionZ) * Time.deltaTime * Speed);

                }
            }

            //resets the ball when out of bounds
            else
            {
                resetBall();
            }

        }
        else
        {
            //game over call
            Debug.Log("GAME OVER");
            if (Player1Point == 7)
            {
                winner = "Player 1";
                Debug.Log("Player 1 Wins");
            }
            else
            {
                winner = "Player 2";
                Debug.Log("Player 2 Wins");
            }

        }


    }
    void OnCollisionEnter(Collision col)
    {

        // Point scoring
        if (col.gameObject.name == "Wall X" || col.gameObject.name == "Wall X (1)")
        {
            resetBall();
            if (col.gameObject.name == "Wall X")
            {
                Player2Point += 1;
            }
            else if(col.gameObject.name == "Wall X (1)")
            {
                Player1Point += 1;
            }

        }

        //Bounce of Balls
        else if (col.gameObject.name == "Wall Z" || col.gameObject.name == "Wall Z (1)")
        {
            SpeedIncrease += 0.25;
            Speed = Mathf.RoundToInt((float)SpeedIncrease);
            AiMovement.speedIncrease += ((double)Random.Range(15, 20))/100;
            AiMovement.Speed = Mathf.RoundToInt((float)AiMovement.speedIncrease);

            DirectionX = DirectionX * -1;

            //Debug.Log("Bounced of Wall");
            updateMovement = "BouncedoffZ";

        }

        //Bounce of players
        else if (col.gameObject.name == "Player 1" || col.gameObject.name == "Player 2")
        {
            //Debug.Log("Bounced off Player");
            DirectionZ = DirectionZ * -1;
            updateMovement = "BouncedoffPlayer";
            if (col.gameObject.name == "Player 1")
            {

                canMove = true;
            }
            else if(col.gameObject.name == "Player 2")
            {
                canMove = false;
            }

        }

        else
        {
            Debug.Log("COLLISION ERROR");
        }

    }

    //resets the balls position
    void resetBall()
    {
        if (Random.value < 0.5f)
        {
            DirectionX = 1;
            if (Random.value < 0.5f)
            {
                DirectionZ = 1;
            }
            else
            {
                DirectionZ = -1;
            }
        }
        else
        {
            DirectionX = -1;
            if (Random.value < 0.5f)
            {
                DirectionZ = 1;
            }
            else
            {
                DirectionZ = -1;
            }
        }
        AiMovement.speedIncrease = 8;
        Instantiate(gameObject, Pos, Quaternion.identity);
        Destroy(gameObject);
    }

    //countdown at the start of the game
    IEnumerator waitThreeSeconds()
    {
        
        yield return new WaitForSeconds(3);
        if (Random.value < 0.5f)
        {
            DirectionX = 1;
            if (Random.value < 0.5f)
            {
                DirectionZ = 1;
            }
            else
            {
                DirectionZ = -1;
            }
        }
        else
        {
            DirectionX = -1;
            if (Random.value < 0.5f)
            {
                DirectionZ = 1;
            }
            else
            {
                DirectionZ = -1;
            }
        }
        updateMovement = "Initial";

       
    }

}
