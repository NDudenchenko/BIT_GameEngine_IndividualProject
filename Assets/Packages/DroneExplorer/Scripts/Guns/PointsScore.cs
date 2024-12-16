using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsScore : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;

    private int Score = 0;

    public void AddPoints(int pointsToAdd)
    {
        Score += pointsToAdd;
        ScoreText.text = Score + "";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
