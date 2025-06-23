using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour
{
    [SerializeField] Image Startimage;
    [SerializeField] Image Endimage;
    public Color colorOn;
    public Color colorOff;
    bool once;
    bool isStart;

    // Start is called before the first frame update
    void Start()
    {
        once = false;
        isStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0f)
        {
            if (once == false)      //falceなら１度だけ色変えを実行して、その後反応しないようになる
            {
                StartSelected();
                once = true;
            }
        }
        if (Input.GetAxis("Vertical") < 0f)
        {
            if (once == false)      //falceなら１度だけ色変えを実行して、その後反応しないようになる
            {
                EndSelected();
                once = true;
            }
        }
        if (Input.GetAxis("Vertical") == 0f)                     //つまり0（押してない状態）だとonceがfalseに戻り、色変え関数が反応するようになる
        {
            once = false;
        }


        //選択時の処理
        if (Gamepad.current.buttonNorth.wasPressedThisFrame)
        {
            if (isStart == true)
            {
                SceneManager.LoadScene("HowToPlayScene");        //※　操作説明シーンへ
            }
            if (isStart == false)
            {
                Debug.Log("終わるはず");
                Application.Quit();
            }
        }
    }

    void StartSelected()
    {
        Startimage.GetComponent<Image>().color = colorOn;
        Endimage.GetComponent<Image>().color = colorOff;       //
        isStart = true;
    }

    void EndSelected()
    {
        Endimage.GetComponent<Image>().color = colorOn;       //
        Startimage.GetComponent<Image>().color = colorOff;
        isStart = false;
    }
}
