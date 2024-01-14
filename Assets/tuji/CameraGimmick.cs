using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���͈͂ɂ���v���C���[�����m(�Ď��J����)
/// </summary>
public class CameraGimmick : MonoBehaviour
{
    //�������Ԃ��߂�����
    public bool m_isTimeOver = false;

    //�͈͓��ɂ���鎞��(5�b)
    private float m_rangeTime = 5.0f;

    //���W�ۑ��p
    //private Vector3 m_position;

    // Start is called before the first frame update
    void Start()
    {
        //m_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(m_rangeTime);
        //if (transform.position != m_position)
        //{
        //    m_rangeTime -= 0.01f;
        //}

        //m_position = transform.position;

        //�������ԉ߂�����
        if (m_rangeTime<=0)
        {
            //���̃N���X�Ɏ����Ă�
            m_isTimeOver = true;
        }
    }


    //�͈͓��ɂ����ꍇ�ɌĂяo�����
    //�������ĂȂ��Ɗ��m����Ȃ�
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        //�v���C���[�̏ꍇ�̂�
        if (collision.gameObject.tag=="Player")
        {
            if (!m_isTimeOver)
            {
                m_rangeTime -= 0.1f;
            }
        }

    }
}
