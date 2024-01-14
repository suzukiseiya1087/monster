using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 一定範囲にいるプレイヤーを検知(監視カメラ)
/// </summary>
public class CameraGimmick : MonoBehaviour
{
    //制限時間を過ぎたら
    public bool m_isTimeOver = false;

    //範囲内にいれる時間(5秒)
    private float m_rangeTime = 5.0f;

    //座標保存用
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

        //制限時間過ぎたら
        if (m_rangeTime<=0)
        {
            //他のクラスに持ってく
            m_isTimeOver = true;
        }
    }


    //範囲内にいた場合に呼び出される
    //※動いてないと感知されない
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        //プレイヤーの場合のみ
        if (collision.gameObject.tag=="Player")
        {
            if (!m_isTimeOver)
            {
                m_rangeTime -= 0.1f;
            }
        }

    }
}
