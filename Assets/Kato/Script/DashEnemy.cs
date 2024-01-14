using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : MonoBehaviour
{
    //���x
    float m_velocity;
    //�v���C���[�𔭌����邽�߂̉~
    //���a
    [SerializeField]float m_radian;
    //���S���W
    float m_centerX;
    float m_centerY;
    //�v���C���[1�̍��W
    float m_player1X;
    float m_player1Y;
    //�v���C���[2�̍��W
    float m_player2X;
    float m_player2Y;
    //�����������ǂ���
    int m_search;

    //�v���C���[
    [SerializeField] GameObject m_player1;
    [SerializeField] GameObject m_player2;

    // Start is called before the first frame update
    void Start()
    {
        //�ϐ��ւ̑��
        m_velocity = 0.0f;
        m_radian = 0.5f;
        m_search = 0;

        //�Q�[���I�u�W�F�N�g�ւ̑��
        m_player1 = GameObject.Find("Player1");
        m_player2 = GameObject.Find("Player2");

        //���S���W����
        m_centerX = transform.position.x;
        m_centerY = transform.position.y;
        //�v���C���[1�̍��W����
        m_player1X = m_player1.transform.position.x;
        m_player1Y = m_player1.transform.position.y;
        //�v���C���[2�̍��W����
        m_player2X = m_player2.transform.position.x;
        m_player2Y = m_player2.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //�ʏ펞
        transform.Translate(m_velocity, 0, 0);

        //�ːi��
        //�~�̒��ɂ���v���C���[��������
        if (m_search == 0)
        {
            Search();
            m_velocity = -0.002f;
        }

        //�v���C���[1���������ꍇ
        else if(m_search == 1)
        {
            //�v���C���[1�ƓG��X���W�̍�
            float dif;
            dif = m_centerX - m_player1X;
            //�v���C���[1����������ɓːi����
            if(dif > 0)
            {
                m_velocity = -0.02f;
            }
            else
            {
                m_velocity = 0.02f;
            }
            ////�ːi��ԂɂȂ�
            //m_search = 3;
        }

        //�v���C���[2���������ꍇ
        else if (m_search == 2)
        {
            //�v���C���[2�ƓG��X���W�̍�
            float dif;
            dif = m_centerX - m_player2X;
            //�v���C���[2����������ɓːi����
            if (dif > 0)
            {
                m_velocity = 0.02f;
            }
            else
            {
                m_velocity = -0.02f;
            }
            ////�ːi��ԂɂȂ�
            //m_search = 3;
        }
    }

    void Search()
    {
        //�v���C���[1���~�ɓ�����
        if (
            (m_centerX - m_player1X) * (m_centerX - m_player1X) +
            (m_centerY - m_player1Y) * (m_centerY - m_player1Y) >= 
            m_radian * m_radian
            )
        {
            m_search = 1;
        }
        //�v���C���[2���~�ɓ�����
        else if(
            (m_centerX - m_player2X) * (m_centerX - m_player2X) +
            (m_centerY - m_player2Y) * (m_centerY - m_player2Y) <= 
            m_radian * m_radian
            )
        {
            m_search = 2;
        }
    }
}
