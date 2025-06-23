using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrub_InvisibleScript : MonoBehaviour
{
    public GameObject target;
    //public Color ShurbOFF;
    [SerializeField] SpriteRenderer Shrub;
    float fadeSpeed = 0.01f;        //透明度が変わるスピードを管理
    float red, green, blue, alfa;   //草むらの色、不透明度を管理

    // Start is called before the first frame update
    void Start()
    {
        red = Shrub.color.r;
        green = Shrub.color.g;
        blue = Shrub.color.b;
        alfa = Shrub.color.a;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 camera = target.transform.position;
        float dis = Vector3.Distance(camera, this.transform.position);
        if (dis < 5)
        {
            alfa -= fadeSpeed;          // b)不透明度を徐々に下げる
            SetAlpha();                 // c)変更した透明度を草むらに反映する
            //Hrub.GetComponent<SpriteRenderer>().color = ShurbOFF;
        }

    }
    void SetAlpha()
    {
        Shrub.color = new Color(red, green, blue, alfa);
    }
}
