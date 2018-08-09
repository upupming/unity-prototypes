using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour {

    public GameObject basketPrefab;
    public int numBasket = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList = new List<GameObject>();

	// Use this for initialization
	void Start () {
		for(int i = 0; i<3; i++)
        {
            GameObject basket = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            basket.transform.position = pos;

            basketList.Add(basket);
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void AppleDestroyed()
    {
        // 清除所有苹果
        GameObject[] allAppleArray = GameObject.FindGameObjectsWithTag("Apple");

        foreach(GameObject apple in allAppleArray)
        {
            Destroy(apple);
        }
        // 消除一个篮筐
        Destroy(basketList[basketList.Count - 1]);
        basketList.RemoveAt(basketList.Count - 1);

        if(basketList.Count == 0)
        {
            
            SceneManager.LoadScene("_Scenes/Scene_0", LoadSceneMode.Single);
        }
    }
}
