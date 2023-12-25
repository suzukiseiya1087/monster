using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public class PlayerBullet : MonoBehaviour
{
    public bool lr;

    void Start()
    {
        //���E�m�F
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

//���@�̃X�N���v�g
public class MainCharacter : MonoBehaviour
{
    public GameObject tama;

    void FixedUpdate()
    {
        //�V���b�g
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //�v���n�u����
            GameObject playerShot = Instantiate(tama) as GameObject;
            playerShot.transform.position = this.transform.position;
        }
    }
}
