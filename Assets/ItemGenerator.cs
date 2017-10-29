using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    //unitychanのオブジェクト(追加)
    private GameObject unitychan;

    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //ゴール地点
    private int goalPos = 70;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    //unitychanとの距離(追加)
    private float difference;
    
    // Use this for initialization
    void Start()
    {
        //Unityちゃんのオブジェクトを取得(追加)
        this.unitychan = GameObject.Find("unitychan");
        //繰り返し処理を呼び出す(追加)
        StartCoroutine("coRoutine");
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    //繰り返し処理:アイテムを一定時間ごとに生成(追加)
    IEnumerator coRoutine()
    {
        //ゴールに近づくまで生成を繰り返す(追加)
        while (unitychan.transform.position.z <= goalPos)
        {
            //unitychanとの距離を設定(追加)
            float difference = this.unitychan.transform.position.z + this.unitychan.transform.forward.z * Random.Range(40,50);

            //アイテム生成の処理(既存の処理)
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab) as GameObject;
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, difference);
                }
            }
            else
            {
                //レーンごとにアイテムを生成
                for (int j = -1; j < 2; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, difference + offsetZ);
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, difference + offsetZ);
                    }
                }
            }

            //時間間隔を指定(追加)
            yield return new WaitForSeconds(seconds: 1.0f);
        }

      

    }



}
