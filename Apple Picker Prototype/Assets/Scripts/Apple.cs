using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
    public static float bottomY = -20f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.y < bottomY)
        {
            Destroy(this.gameObject);

            // 通知主相机
            ApplePicker applePicker = Camera.main.GetComponent<ApplePicker>();
            applePicker.AppleDestroyed();
        }
	}
}
