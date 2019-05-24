using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreUI : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text ="＄"+ Score.GetScore.ToString();
        if (Score.GetScore >= 0) scoreText.color = Color.green;
        else if (Score.GetScore <= 0) scoreText.color = Color.red;

        

    }
}
