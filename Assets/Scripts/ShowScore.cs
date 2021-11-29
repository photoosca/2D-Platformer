using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    // Start is called before the first frame update
    void FixedUpdate()
    {
        GetComponent<Text>().text = Data.score.ToString("00") + ("/10");
        //GetComponent<Text>().text = Data.score.ToString("0") + ("/10");
    }
}