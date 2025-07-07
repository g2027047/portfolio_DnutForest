using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// オブジェクトに紐付いている関数
public class Final_Ds : MonoBehaviour
{

    void Start()
    {

    }

    // 更新用の関数
    void Update()
    {

        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;
        pos.x += 0.0f* Time.deltaTime;    // x座標へ0.01加算
        pos.y += 0.0f* Time.deltaTime;    // y座標へ0.01加算
        pos.z -= 3.0f* Time.deltaTime;    // z座標へ0.01加算

        myTransform.position = pos;  // 座標を設定

        
    }
}