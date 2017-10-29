using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //画面外に出た場合の処理
    void OnBecameInvisible()
    {
        //画面外に出たのでオブジェクトを消す
        Destroy(this.gameObject);
    }

}
