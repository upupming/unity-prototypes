using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour {
    private Text scoreText;
    private int count = 0;

	// Use this for initialization
	void Start () {
        scoreText = GameObject.Find("Canvas").GetComponentInChildren<Text>();
        scoreText.text = "Score: 0";
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos2D = Input.mousePosition;
        // 主摄像机 z 为 -10，将此 z 设为 10
        mousePos2D.z = -Camera.main.transform.position.z ;
        // 使得此 z 为 0
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if(collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            count++;
            scoreText.text = "Scores: " + count * 100;

            // 更新最高分
            if(count * 100 > HighestScore.score)
            {
                HighestScore.score = count * 100;
            }
        }
    }
}
