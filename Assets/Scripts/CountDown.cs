using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown : MonoBehaviour {

    // Use this for initialization
    void Start() {
        StartCoroutine(waitThreeSeconds());
    }

    // Update is called once per frame
    void Update() {
            
    }

    //Changes the countdown text
    IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSeconds(1);
        GetComponent<TextMesh>().text = "2";
        yield return new WaitForSeconds(1);
        GetComponent<TextMesh>().text = "1";
        yield return new WaitForSeconds(1);
        Destroy(gameObject);

    }
}
