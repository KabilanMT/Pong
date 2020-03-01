using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //exit game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //move player1 with keyboard controls
        if (Input.GetKeyDown(KeyCode.A) && transform.position.x > -4 && Console.showConsole == false)
        {
            Vector3 position = this.transform.position;
            position.x--;
            position.x--;
            this.transform.position = position;
        }
        else if (Input.GetKeyDown(KeyCode.D) && transform.position.x < 3 && Console.showConsole == false)
        {
            Vector3 position = this.transform.position;
            position.x++;
            position.x++;
            this.transform.position = position;
        }
        
        //move player2 with joystick controls
        else if (Input.GetKey(KeyCode.JoystickButton1) && transform.position.x < 3 && Console.showConsole == false)
        {
            Vector3 position = this.transform.position;
            position.x++;
            position.x++;
            this.transform.position = position;
        }
        else if (Input.GetKey(KeyCode.JoystickButton2) && transform.position.x > -4 && Console.showConsole == false)
        {
            Vector3 position = this.transform.position;
            position.x--;
            position.x--;
            this.transform.position = position;
        }

    }
}