using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class PlayerBullet : MonoBehaviour
{
    public bool lr;

    void Start()
    {
        //左右確認
        GameObject player = GameObject.Find("Player2");
        lr = player.GetComponent<SpriteRenderer>().flipX;
    }

    void FixedUpdate()
    {
        if (lr)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-20, 0);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
        }

    }
}

//自機のスクリプト
public class MainCharacter : MonoBehaviour
{
    public GameObject tama;

    void FixedUpdate()
    {
        //ショット
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //プレハブ召喚
            GameObject playerShot = Instantiate(tama) as GameObject;
            playerShot.transform.position = this.transform.position;
        }
    }
}
