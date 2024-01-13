using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 仮の移動処理
        if (Input.GetKey(KeyCode.RightArrow))
        {// 右方向の移動入力
            Vector2 pos = transform.position;
            pos.x += 0.05f;
            transform.position = pos;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {// 左方向の移動入力
            Vector2 pos = transform.position;
            pos.x -= 0.05f;
            transform.position = pos;
        }
    }
}
