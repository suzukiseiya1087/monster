using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashEnemy : MonoBehaviour
{
    //速度
    float m_velocity;
    //プレイヤーを発見するための円
    //半径
    [SerializeField]float m_radian;
    //中心座標
    float m_centerX;
    float m_centerY;
    //プレイヤー1の座標
    float m_player1X;
    float m_player1Y;
    //プレイヤー2の座標
    float m_player2X;
    float m_player2Y;
    //発見したかどうか
    int m_search;

    //プレイヤー
    [SerializeField] GameObject m_player1;
    [SerializeField] GameObject m_player2;

    // Start is called before the first frame update
    void Start()
    {
        //変数への代入
        m_velocity = 0.0f;
        m_radian = 0.5f;
        m_search = 0;

        //ゲームオブジェクトへの代入
        m_player1 = GameObject.Find("Player1");
        m_player2 = GameObject.Find("Player2");

        //中心座標を代入
        m_centerX = transform.position.x;
        m_centerY = transform.position.y;
        //プレイヤー1の座標を代入
        m_player1X = m_player1.transform.position.x;
        m_player1Y = m_player1.transform.position.y;
        //プレイヤー2の座標を代入
        m_player2X = m_player2.transform.position.x;
        m_player2Y = m_player2.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //通常時
        transform.Translate(m_velocity, 0, 0);

        //突進時
        //円の中にいるプレイヤーを見つける
        if (m_search == 0)
        {
            Search();
            m_velocity = -0.002f;
        }

        //プレイヤー1を見つけた場合
        else if(m_search == 1)
        {
            //プレイヤー1と敵のX座標の差
            float dif;
            dif = m_centerX - m_player1X;
            //プレイヤー1がいる方向に突進する
            if(dif > 0)
            {
                m_velocity = -0.02f;
            }
            else
            {
                m_velocity = 0.02f;
            }
            ////突進状態になる
            //m_search = 3;
        }

        //プレイヤー2を見つけた場合
        else if (m_search == 2)
        {
            //プレイヤー2と敵のX座標の差
            float dif;
            dif = m_centerX - m_player2X;
            //プレイヤー2がいる方向に突進する
            if (dif > 0)
            {
                m_velocity = 0.02f;
            }
            else
            {
                m_velocity = -0.02f;
            }
            ////突進状態になる
            //m_search = 3;
        }
    }

    void Search()
    {
        //プレイヤー1が円に入った
        if (
            (m_centerX - m_player1X) * (m_centerX - m_player1X) +
            (m_centerY - m_player1Y) * (m_centerY - m_player1Y) >= 
            m_radian * m_radian
            )
        {
            m_search = 1;
        }
        //プレイヤー2が円に入った
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
