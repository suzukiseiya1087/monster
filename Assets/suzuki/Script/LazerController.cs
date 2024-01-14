using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour
{
    [SerializeField] private float speed = 5; //銃弾のスピード

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    public void Move()
    {
        Vector3 lazerPos = transform.position; //Vector3型のplayerPosに現在の位置情報を格納
        lazerPos.x += speed * Time.deltaTime; //x座標にspeedを加算
        transform.position = lazerPos; //現在の位置情報に反映させる
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject); // 敵オブジェクトを削除
        }
    }
}