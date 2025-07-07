using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// オブジェクトに紐付いている関数
public class LStraight_move : MonoBehaviour
{
    bool Sidemove;
    float side_d;

    void Start()
    {
        Sidemove = true;
        side_d = Random.Range(0.5f,10f);
    }

    // 更新用の関数
    void Update()
    {
        if (Sidemove == true)
        {
            // transformを取得
            Transform myTransform = this.transform;
            // 座標を取得
            Vector3 pos = myTransform.position;
            pos.x += 5.0f * Time.deltaTime;    // x座標へ0.01加算
            pos.y -= 0.0f * Time.deltaTime;    // y座標へ0.01加算
            pos.z -= 0.0f * Time.deltaTime;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            if(pos.x+5 > side_d)
            {
                Sidemove = false;
            }
        }
        if (Sidemove == false)
        {
            // transformを取得
            Transform myTransform = this.transform;
            // 座標を取得
            Vector3 pos = myTransform.position;
            pos.x += 0.0f * Time.deltaTime;    // x座標へ0.01加算
            pos.y += 0.0f * Time.deltaTime;    // y座標へ0.01加算
            pos.z -= 2.0f * Time.deltaTime;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
        }



    }
}