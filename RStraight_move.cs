using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �I�u�W�F�N�g�ɕR�t���Ă���֐�
public class RStraight_move : MonoBehaviour
{
    bool Sidemove;
    float side_d;

    void Start()
    {
        Sidemove = true;
        side_d = Random.Range(-7.0f, 7.5f);
    }

    // �X�V�p�̊֐�
    void Update()
    {
        Debug.Log("Rside_d=" + side_d);
        if (Sidemove == true)
        {
            // transform���擾
            Transform myTransform = this.transform;
            // ���W���擾
            Vector3 pos = myTransform.position;
            pos.x -= 5.0f * Time.deltaTime;    // x���W��0.01���Z
            pos.y -= 0.0f * Time.deltaTime;    // y���W��0.01���Z
            pos.z -= 0.0f * Time.deltaTime;    // z���W��0.01���Z
            myTransform.position = pos;  // ���W��ݒ�
            Debug.Log("pos.x=" + pos.x);
            if (pos.x < side_d)            //�����ʒu����12�B��������-5���Ă����A���̒n�_�ł���Ɂ|5���Ă��܂��ƃ����_����side_d�i0.5�`10�j��菬�������ɂȂ�Ȃ�I���
            {
                Sidemove = false;
            }
        }
        if (Sidemove == false)
        {
            // transform���擾
            Transform myTransform = this.transform;
            // ���W���擾
            Vector3 pos = myTransform.position;
            pos.x += 0.0f * Time.deltaTime;    // x���W��0.01���Z
            pos.y += 0.0f * Time.deltaTime;    // y���W��0.01���Z
            pos.z -= 0.8f * Time.deltaTime;    // z���W��0.01���Z
            myTransform.position = pos;  // ���W��ݒ�
        }



    }
}