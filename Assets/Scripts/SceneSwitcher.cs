using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{

    //used to tell whether or not it's single or multiplayer
    public static bool singlePlayer;


    //resets all static variables on homescreen
    void Start()
    {

        BallMovement.Player1Point = 0;
        BallMovement.Player2Point = 0;
        BallMovement.winner = null;
        BallMovement.Speed = 10f;


    }

    public void Update()
    {
        //exit game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void GoToMain()
    {
        SceneManager.LoadScene("HomeScreen");
    }

    public void SinglePlayer()
    {
        singlePlayer = true;
        SceneManager.LoadScene("PongGameplay");
    }

    public void MultiPlayer()
    {
        singlePlayer = false;
        SceneManager.LoadScene("PongGameplay");
    }


    //opens a txt file that shows you the game mechanics
    public void OpenTxt()
    {
        string realPath = Application.dataPath + "/ReadMe.txt";

        if (!System.IO.File.Exists(realPath))
        {
            if (!System.IO.Directory.Exists(Application.persistentDataPath + "/PATH/"))
            {
                System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/PATH/");
            }
            WWW reader = new WWW(Application.streamingAssetsPath + "/PATH/" + realPath);
            while (!reader.isDone) { }
            System.IO.File.WriteAllBytes(realPath, reader.bytes);
        }

        Debug.Log(realPath);
        Application.OpenURL(realPath);

    }
}
