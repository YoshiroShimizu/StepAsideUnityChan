using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {
    //carPefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject cornPrefab;
    //スタート地点
    private int startPos = -160;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    private GameObject unitychan;

    private int itemdifference;

    private float lastposition;

    private float unitychanoffsetZ;

   

    // Use this for initialization
    void Start () {
        this.unitychan = GameObject.Find("unitychan");
        this.itemdifference = Random.Range(40, 50);
        this.lastposition = this.unitychan.transform.position.z;



    }
	
	// Update is called once per frame
	void Update () {
        
        this.unitychanoffsetZ = this.unitychan.transform.position.z + itemdifference;


        //一定の距離ごとにアイテムを生成
        if(this.unitychan.transform.position.z-this.lastposition>15 && this.goalPos> this.unitychanoffsetZ)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(1, 11);
            

            if (num <= 2 )
            {
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(cornPrefab) as GameObject;

                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, this.unitychanoffsetZ);
                    
                }
                this.lastposition += 15;
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くz座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置：30％車配置：10％何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, this.unitychanoffsetZ + offsetZ);
                        
                    }
                    
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, this.unitychanoffsetZ + offsetZ);
                       

                    }
                }
                this.lastposition += 15;
            }
        }
    }
}
