using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    float timer;
    public int second;
    public Color CursorCollorOFF;
    public Color TimeUpCollorON;
    [SerializeField] Text text;
    [SerializeField] Text TIMEUPtex;
    [SerializeField] Image Cursorimage;

    [SerializeField] Image fadeImage;
    public bool isFadeOut = false;  //フェードアウト処理の開始、完了を管理するフラグ
    float fadeSpeed = 0.007f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //パネルの色、不透明度を管理

    // Start is called before the first frame update
    void Start()
    {
        //fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

        Debug.Log("タイマー開始");
        timer = 180;     //デフォルトは180
        second = (int)timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1.0f * Time.deltaTime;
        second = (int)timer;
        if (timer > 0)
        {
            text.text = "残り：" + second.ToString() + "　秒";
        }
        else
        {
            text.text = "残り：　0秒";
            Cursorimage.GetComponent<Image>().color = CursorCollorOFF;
            TIMEUPtex.GetComponent<Text>().color = TimeUpCollorON;
            StartFadeOut();
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;   // a)パネルの表示をオンにする
        alfa += fadeSpeed;          // b)不透明度を徐々にあげる
        SetAlpha();                 // c)変更した透明度をパネルに反映する
        if (alfa >= 1)              // d)完全に不透明になったら処理を抜ける
        {
            isFadeOut = false;
            SceneManager.LoadScene("result");        //※　リザルトシーンへ
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
