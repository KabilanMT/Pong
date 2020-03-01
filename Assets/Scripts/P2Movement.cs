using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour {

	// Use this for initialization
	void Start () {

        if (SceneSwitcher.singlePlayer == true)
        {
            Destroy(GetComponent<P2Movement>());
        }

        else if(SceneSwitcher.singlePlayer == false)
        {
            Destroy(GetComponent<AiMovement>());
        }
        
        else
        {
            Debug.Log("Player Selection error");
        }
    }

    // Update is called once per frame
    void Update() {

            //moves player2 based on keypresses and allowed movement
            if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -4 && Console.showConsole == false)
            {
                Vector3 position = this.transform.position;
                position.x--;
                position.x--;
                this.transform.position = position;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 3 && Console.showConsole == false)
            {
                Vector3 position = this.transform.position;
                position.x++;
                position.x++;
            this.transform.position = position;
            }
    }
  
}
