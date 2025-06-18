using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo_Script : MonoBehaviour
{
    public GameObject Runkobj;
    [SerializeField] Text text;
    int combo = 0;
    int combo_last = 0;     //  ランク上昇毎に記憶。ミスで０に
    public int rank = 0;        //  0:D     1:C     2:B     3:A     4以上:S     ランク段階処理用変数。ランクスクリプトに使う為パブリック

    // Start is called before the first frame update
    void Start()
    {
        combo = 0;
        combo_last = 0;
        rank = 0;
        text.text = combo + " コンボ！";
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log("combo_last"+combo_last);
    }

    public void PlusOne()       //　真ん中にあたると呼び出される。コンボ数を+1する
    {
        combo++;
        text.text = combo + "　コンボ！";
        if (combo_last * 2 + 1 == combo)    //　D　→　C   のようにランク上昇する条件、前のランクアップ時のコンボ数*2+1のコンボが必要
        {
            rank ++;
            Runkobj.GetComponent<RankScript>().Runk();  //  ランクスクリプトへ
            combo_last = combo;
            //Debug.Log("Rank::  "+ rank);
        }
    }

    public void ResetC_R()        //　コンボとランクのリセット処理(ResetZoneスクリプトにて接触により呼ばれる。Dナッツしか当たる対象がいない＝Dナッツが当たると発動)
    {
        combo = 0;
        combo_last = 0;
        rank = 0;
        text.text = combo + "　コンボ！";
        Runkobj.GetComponent<RankScript>().Runk();  //  ランクスクリプトへ
    }
}
