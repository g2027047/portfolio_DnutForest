using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    int s, a, b, c, d, miss, total = 0;
    public Text scoreStext;
    public Text scoreAtext;
    public Text scoreBtext;
    public Text scoreCtext;
    public Text scoreDtext;
    public Text Totalscoretext;

    // Start is called before the first frame update
    void Start()
    {
        //メインからゲッターを呼び出す
        s = RankScript.rS;
        a = RankScript.rA;
        b = RankScript.rB;
        c = RankScript.rC;
        d = RankScript.rD;

        //各text型の変数に各オブジェクトを探してそれぞれの<text>を格納
        //scoreStext = GameObject.Find("scoreS").GetComponent<Text>(); 
        //scoreAtext = GameObject.Find("scoreA").GetComponent<Text>();
        //scoreBtext = GameObject.Find("scoreB").GetComponent<Text>();
        //scoreCtext = GameObject.Find("scoreC").GetComponent<Text>();
        //scoreDtext = GameObject.Find("scoreD").GetComponent<Text>();
        //scoremisstext = GameObject.Find("scoremiss").GetComponent<Text>();
        //Totalscoretext = GameObject.Find("Totalscore").GetComponent<Text>();


        //s～missの撃破数（つまりプレイ中のスクリプトから持ってきたデータ）を表示する
        scoreStext.text = string.Format("{0}", s);
        scoreAtext.text = string.Format("{0}", a);
        scoreBtext.text = string.Format("{0}", b);
        scoreCtext.text = string.Format("{0}", c);
        scoreDtext.text = string.Format("{0}", d);

        //s～missは、変数×プレイしてるときに記憶されてる撃破数＝合計金額に更新する
        s *= 250;
        a *= 200;
        b *= 150;
        c *= 120;
        d *= 100;

        //上記で更新されたS～Dの合計金額｛（s～dの値はこの時点で既に「単価×数」の値に更新されている）｝をtotalで表示。
        total = s + a + b + c + d;

        //totalscoreを表示
        Totalscoretext.text = string.Format("{0}", total);
    }

    // Update is called once per frame
    void Update()
    {
        //　Yボタンでタイトルへ戻る
        if (Gamepad.current.buttonNorth.wasPressedThisFrame)
        {
            Debug.Log("タイトルへ戻る");
            SceneManager.LoadScene("TitleScene");        //※　タイトルシーンへ
        }
    }
}
