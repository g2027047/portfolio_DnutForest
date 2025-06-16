using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankScript : MonoBehaviour
{
    [SerializeField] Text ranktext;
    public Combo_Script combo_Script; //  参照するスクリプト
    //int getrank ; //　参照する為の変数
    public static int rD = 0, rC = 0, rB = 0, rA = 0, rS = 0;      //  ランク毎の穴あけ個体数を記録するための変数。リザルト画面でも使うためパブリック

    public Color Dcolor;
    public Color Ccolor;
    public Color Bcolor;
    public Color Acolor;
    public Color Scolor;

    // Start is called before the first frame update
    void Start()
    {
        rD = 0;
        rC = 0;
        rB = 0;
        rA = 0;
        rS = 0;
        ranktext.text = "D";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Runk()                                                          //  現在ランク表示
    {
        //getrank = combo_Script.rank;
        if(combo_Script.rank == 0)  // Dランクの場合（リセットされるとこれ）
        {
            ranktext.text = "D";
            ranktext.GetComponent<Text>().color = Dcolor;
        }
        if (combo_Script.rank == 1)
        {
            ranktext.text = "C";
            ranktext.GetComponent<Text>().color = Ccolor;
        }
        if (combo_Script.rank == 2)
        {
            ranktext.text = "B";
            ranktext.GetComponent<Text>().color = Bcolor;
        }
        if (combo_Script.rank == 3)
        {
            ranktext.text = "A";
            ranktext.GetComponent<Text>().color = Acolor;
        }
        if (combo_Script.rank >= 4)
        {
            ranktext.text = "S";
            ranktext.GetComponent<Text>().color = Scolor;
        }
    }

    public void PointCount()                                                    //  ランク毎のポイント数え
    {
        if (combo_Script.rank == 0)  // Dランクの場合（リセットされるとこれ）
        {
            rD++;
            Debug.Log("Dランク：" + rD);
        }
        if (combo_Script.rank == 1)
        {
            rC++;
        }
        if (combo_Script.rank == 2)
        {
            rB++;
            Debug.Log("Bランク：" + rB);
        }
        if (combo_Script.rank == 3)
        {
            rA++;
        }
        if (combo_Script.rank >= 4)
        {
            rS++;
            Debug.Log("Sランク：" + rS);
        }
    }
}
