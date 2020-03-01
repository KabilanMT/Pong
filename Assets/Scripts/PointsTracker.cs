using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;
using UnityEngine.SceneManagement;

public class PointsTracker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<TextMesh>().text = "P1:                 P2:";
    }


    // Update is called once per frame
    void Update () {
        float P1 = BallMovement.Player1Point;
        float P2 = BallMovement.Player2Point;

        string P1toString = P1.ToString();
        string P2toString = P2.ToString();

        //displays winner
        if(BallMovement.winner == null)
        {
            GetComponent<TextMesh>().text = "P1: " + P1toString + "               P2: " + P2toString;
        }
        else
        {
            Debug.Log(BallMovement.winner);
            GetComponent<TextMesh>().text = "The winner is " + BallMovement.winner + "!";
            StartCoroutine(waitThreeSeconds());
        }


    }

    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSeconds(4);
        GetComponent<TextMesh>().text = "Redirecting to Home Screen";
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("HomeScreen");
    }
}
