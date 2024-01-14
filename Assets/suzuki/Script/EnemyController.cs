using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        // もし衝突したオブジェクトがプレイヤーの弾だった場合
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Destroy(gameObject); // このエネミーを破壊する
        }
    }
}
