using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour {


    public static float Speed;
    public static double speedIncrease;
    // Use this for initialization
    void Start() {
        Speed = 8f;
        speedIncrease = 8;
    }

    // Update is called once per frame
    void Update() {

        float Step = Speed * Time.deltaTime;

        //moves the ai towards the balls x-axis and returns to center once it hits it till the player hits it back
        if (BallMovement.canMove == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(BallMovement.ballXPosition, 2, 11), Step);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 2, 11), Step);
        }
      

         
       // transform.position = (new Vector3(BallMovement.ballXPosition, 2, -11));
    }
}


   