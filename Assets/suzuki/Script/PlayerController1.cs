using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField] private GameObject lazer; //レーザープレハブを格納
    [SerializeField] private Transform attackPoint;//アタックポイントを格納

    [SerializeField] private float attackTime = 0.02f; //攻撃の間隔
    private float currentAttackTime; //攻撃の間隔を管理
    private bool canAttack; //攻撃可能状態かを指定するフラグ
   

    public CameraController cameraController; // カメラ制御クラス   

    private float Speed = 0.09f;
    //float currentspeed;
    // Start is called before the first frame update
    void Start()
    {
        //currentspeed = Speed;
        rigidbody2D = GetComponent<Rigidbody2D>(); // Rigidbody2Dコンポーネントを取得
        currentAttackTime = attackTime; //currentAttackTimeにattackTimeをセット。


        // カメラ初期位置
        cameraController.SetPosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
        // Check if W key is pressed and player has not exceeded the jump count
     
        //~省略~
        Attack();
        // カメラに自身の座標を渡す
        cameraController.SetPosition(transform.position);
    }

    private void MoveUpdate()
    {
        Vector2 position = transform.position;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            position.x -= Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            position.x += Speed;
        }
        transform.position = position;
    }
    //    float moveInput = 0f;
    //    if (Input.GetKey(KeyCode.LeftArrow))
    //    {
    //        moveInput = -1f;
    //    }
    //    if (Input.GetKey(KeyCode.RightArrow))
    //    {
    //        moveInput = 1f;
    //    }
    //    rigidbody2D.velocity = new Vector2(moveInput * Speed, rigidbody2D.velocity.y);
    //}
    /// <summary>
	/// Updateから呼び出されるジャンプ入力処理
	/// </summar
    void Attack()
    {
        attackTime += Time.deltaTime; //attackTimeに毎フレームの時間を加算していく

        if (attackTime > currentAttackTime)
        {
            canAttack = true; //指定時間を超えたら攻撃可能にする
        }

        if (Input.GetKeyDown(KeyCode.K)) //Kキーを押したら
        {
            if (canAttack)
            {
                //第一引数に生成するオブジェクト、第二引数にVector3型の座標、第三引数に回転の情報
                Instantiate(lazer, attackPoint.position, Quaternion.identity);
                canAttack = false;　//攻撃フラグをfalseにする
                attackTime = 0f;　//attackTimeを0に戻す
            }
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}