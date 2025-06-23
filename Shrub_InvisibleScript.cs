using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrub_InvisibleScript : MonoBehaviour
{
    public GameObject target;
    //public Color ShurbOFF;
    [SerializeField] SpriteRenderer Shrub;
    float fadeSpeed = 0.01f;        //�����x���ς��X�s�[�h���Ǘ�
    float red, green, blue, alfa;   //���ނ�̐F�A�s�����x���Ǘ�

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
            alfa -= fadeSpeed;          // b)�s�����x�����X�ɉ�����
            SetAlpha();                 // c)�ύX���������x�𑐂ނ�ɔ��f����
            //Hrub.GetComponent<SpriteRenderer>().color = ShurbOFF;
        }

    }
    void SetAlpha()
    {
        Shrub.color = new Color(red, green, blue, alfa);
    }
}
