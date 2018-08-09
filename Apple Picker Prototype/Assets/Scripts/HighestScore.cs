using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighestScore : MonoBehaviour {
    static public int score = 0;
    private Text highestScore;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("ApplePickerHighestScore"))
        {
            score = PlayerPrefs.GetInt("ApplePickerHighestScore");
        }

        // 首次使用需创建
        PlayerPrefs.SetInt("ApplePickerHighestScore", score);
    }

    // Use this for initialization
    void Start () {

         highestScore = GameObject.Find("Canvas").GetComponentsInChildren<Text>()[1];
    }
	
	// Update is called once per frame
	void Update () {
        highestScore.text = "Highest score: " + score;

        if(score > PlayerPrefs.GetInt("ApplePickerHighestScore"))
        {
            PlayerPrefs.SetInt("ApplePickerHighestScore", score);
        }

    }
}
