using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleCommands : MonoBehaviour {


    public InputField InputField;
    public Renderer rend;


    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

    }

    public void getCommand()
    {
        

        //changes backgorund color
        if(InputField.text.StartsWith("color ") )
        {
            string decodedText = InputField.text.Replace("color ", "");
            Color MyColour = Color.clear; ColorUtility.TryParseHtmlString(decodedText, out MyColour);
            rend.material.color = MyColour;
        }

        //changes ball speed till next bounce
        else if (InputField.text.StartsWith("speed "))
        {
            string decodedText = InputField.text.Replace("speed ", "");
            if (decodedText.All(char.IsDigit))
            {
                BallMovement.Speed = float.Parse(decodedText);
            }


        }

    }
}
