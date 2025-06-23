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
    public bool isFadeOut = false;  //�t�F�[�h�A�E�g�����̊J�n�A�������Ǘ�����t���O
    float fadeSpeed = 0.007f;        //�����x���ς��X�s�[�h���Ǘ�
    float red, green, blue, alfa;   //�p�l���̐F�A�s�����x���Ǘ�

    // Start is called before the first frame update
    void Start()
    {
        //fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

        Debug.Log("�^�C�}�[�J�n");
        timer = 180;     //�f�t�H���g��180
        second = (int)timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1.0f * Time.deltaTime;
        second = (int)timer;
        if (timer > 0)
        {
            text.text = "�c��F" + second.ToString() + "�@�b";
        }
        else
        {
            text.text = "�c��F�@0�b";
            Cursorimage.GetComponent<Image>().color = CursorCollorOFF;
            TIMEUPtex.GetComponent<Text>().color = TimeUpCollorON;
            StartFadeOut();
        }
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;   // a)�p�l���̕\�����I���ɂ���
        alfa += fadeSpeed;          // b)�s�����x�����X�ɂ�����
        SetAlpha();                 // c)�ύX���������x���p�l���ɔ��f����
        if (alfa >= 1)              // d)���S�ɕs�����ɂȂ����珈���𔲂���
        {
            isFadeOut = false;
            SceneManager.LoadScene("result");        //���@���U���g�V�[����
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
