using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour {

    // Use this for initialization

    public static bool showConsole;
    public GameObject inputField;

    void Start () {
        inputField.SetActive(false);
        showConsole = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            showConsole = !showConsole;
        }

        //play or pause the game
        if(showConsole == true)
        {
            inputField.SetActive(true);
            Time.timeScale = 0;


        }
        else if(showConsole == false)
        {
            inputField.SetActive(false);
            Time.timeScale = 1;

        }
        else {
            Debug.Log("Console Error");
        }
       
    }
}
