using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class HowToPlayScript : MonoBehaviour
{
    //[SerializeField] Text NowLoading_image;
    //public Color colorOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Y�Ŗ{�҂�
        if (Gamepad.current.buttonNorth.wasPressedThisFrame)
        {
            //NowLoading_image.GetComponent<Text>().color = colorOn;          //�قڂقڈӖ��Ȃ�NowLoading�c
            SceneManager.LoadScene("SampleScene");        //���@�{�҃V�[����
        }
    }
}
