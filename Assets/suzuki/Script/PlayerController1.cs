using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private SpriteRenderer spriteRenderer;

    [HideInInspector] public float Speed;
    [HideInInspector] public bool rightFacing;//向いてる方向(true,右向き,false,左向き)

    // Start is called before the first frame update
    void Start()
    {
        //コンポーネントを取得
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rightFacing = true;//最初は右向き
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();

    }
    private void MoveUpdate()
    {
        //仮の移動処理
        if (Input.GetKey(KeyCode.RightArrow))
        {//右方向の移動入力
            //X方向移動速度をプラスに設定
            Speed = 6.0f;
            //右向きフラグon
            rightFacing = true;
            //スプライトを通常の向きで表示
            spriteRenderer.flipX = false;
        }
        //仮の移動処理
        if (Input.GetKey(KeyCode.LeftArrow))
        {//左方向の移動入力
            //X方向移動速度をマイナスに設定
            Speed = -6.0f;
            //右向きフラグoff
            rightFacing = false;
            //スプライトを左右反転した向きで表示
            spriteRenderer.flipX = true;
        }
        else
        {//入力なし
            //X方向の移動停止
            Speed = 0.0f;
        }
    }
    private void FixedUpdate()
    {
        //移動速度ベクトル現在地を取得
        Vector2 velocity = rigidbody2D.velocity;
        //X方向の速度入力から決定
        velocity.x = Speed;
        //計算した移動速度ベクトルをRigidbody2Dに反映
        rigidbody2D.velocity = velocity;
    }
}