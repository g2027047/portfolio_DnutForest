using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// オブジェクトに紐付いている関数
public class RStraight_move : MonoBehaviour
{
    bool Sidemove;
    float side_d;

    void Start()
    {
        Sidemove = true;
        side_d = Random.Range(-7.0f, 7.5f);
    }

    // 更新用の関数
    void Update()
    {
        Debug.Log("Rside_d=" + side_d);
        if (Sidemove == true)
        {
            // transformを取得
            Transform myTransform = this.transform;
            // 座標を取得
            Vector3 pos = myTransform.position;
            pos.x -= 5.0f * Time.deltaTime;    // x座標へ0.01加算
            pos.y -= 0.0f * Time.deltaTime;    // y座標へ0.01加算
            pos.z -= 0.0f * Time.deltaTime;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
            Debug.Log("pos.x=" + pos.x);
            if (pos.x < side_d)            //初期位置ｘは12。そこから-5していき、その地点でさらに－5してしまうとランダム数side_d（0.5～10）より小さい数になるなら終わる
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
            pos.z -= 0.8f * Time.deltaTime;    // z座標へ0.01加算
            myTransform.position = pos;  // 座標を設定
        }



    }
}