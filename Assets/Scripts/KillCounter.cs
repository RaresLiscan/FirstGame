using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillCounter : MonoBehaviour
{

    public int counter;
    public int obstaclesPassed;
    public Text counterText;
    public Text obstaclesPassedText;

    private void Start()
    {
        counterText.text = "Kills: 0";
    }

    private void Update()
    {
        counterText.text = "Kills: " + counter.ToString();
    }
}
