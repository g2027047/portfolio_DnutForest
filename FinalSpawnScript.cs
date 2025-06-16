using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalSpawnScript : MonoBehaviour
{
    public GameObject target;
    public GameObject FinalDnut;
    public TimerScript timerScript; //  参照するスクリプト
    bool spawn;
    //float z;
    //bool zlock;

    // Start is called before the first frame update
    void Start()
    {
        //zlock = false;
        spawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        //                                          ＝＝＝＝＝出現条件（※　残り60秒　※）＝＝＝＝＝

        if (timerScript.second <= 65 & spawn == false)
        {
            DnutSpawn();
            Debug.Log("ラスト＿スポーン範囲に到達");
            spawn = true;
        }

        //                                                          ＝＝＝＝＝出現＝＝＝＝＝
        //オブジェクトの座標
        //float x = Random.Range(-9.5f, 9.5f);        //横方向は-9.5f～9.5f
        //float y = Random.Range(-4f, 4f);            //縦方向は-4f～4f
        //float z = Random.Range(-10f, -40f);           //奥行きは10f~40f

        //　obj=test_Dnutとして、ここ（Vector3(x,y,z)に配置し、向きはそのままにすること）
        //GameObject obj = Instantiate(test_Dnut, new Vector3(x, y, z), test_Dnut.transform.rotation);



    }

    //                                                      ＝＝＝＝＝近づいて来る＝＝＝＝＝
    //  プレイヤーへ直進
    void DnutSpawn()
    {
        Debug.Log("実行：スポーン");
        GameObject obj = Instantiate(FinalDnut, this.transform.position, FinalDnut.transform.rotation);
    }

}
