using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �I�u�W�F�N�g�ɕR�t���Ă���֐�
public class LStraight_move : MonoBehaviour
{
    bool Sidemove;
    float side_d;

    void Start()
    {
        Sidemove = true;
        side_d = Random.Range(0.5f,10f);
    }

    // �X�V�p�̊֐�
    void Update()
    {
        if (Sidemove == true)
        {
            // transform���擾
            Transform myTransform = this.transform;
            // ���W���擾
            Vector3 pos = myTransform.position;
            pos.x += 5.0f * Time.deltaTime;    // x���W��0.01���Z
            pos.y -= 0.0f * Time.deltaTime;    // y���W��0.01���Z
            pos.z -= 0.0f * Time.deltaTime;    // z���W��0.01���Z
            myTransform.position = pos;  // ���W��ݒ�
            if(pos.x+5 > side_d)
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
            pos.z -= 2.0f * Time.deltaTime;    // z���W��0.01���Z
            myTransform.position = pos;  // ���W��ݒ�
        }



    }
}