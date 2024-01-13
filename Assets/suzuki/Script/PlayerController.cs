using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private int currentWeaponIndex = 0;
    public GameObject[] CaptureGun; // 武器の配列
    [SerializeField] private GameObject lazer; //レーザープレハブを格納
    [SerializeField] private GameObject CaptureGun1;
    [SerializeField] private Transform attackPoint;//アタックポイントを格納

    [SerializeField] private float attackTime = 0.02f; //攻撃の間隔
    private float currentAttackTime; //攻撃の間隔を管理
    private bool canAttack; //攻撃可能状態かを指定するフラグ


    public CameraController cameraController; // カメラ制御クラス   

    private float Speed = 0.01f;
    //float currentspeed;
    // Start is called before the first frame update
    void Start()
    {
        //currentspeed = Speed;
        // 初期の武器を有効にする
        SwitchWeapon(currentWeaponIndex);
        currentAttackTime = attackTime; //currentAttackTimeにattackTimeをセット。


        // カメラ初期位置
        cameraController.SetPosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
        // 武器の切り替え処理
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchWeapon((currentWeaponIndex + 1) % CaptureGun.Length);
        }
        //~省略~
        Attack();
        // カメラに自身の座標を渡す
        cameraController.SetPosition(transform.position);
    }

    private void MoveUpdate()
    {
        Vector2 position = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += Speed;
        }
        transform.position = position;
    }
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

        if (Input.GetKeyDown(KeyCode.Z)) //Kキーを押したら
        {
            if (canAttack)
            {
               if(currentWeaponIndex ==1)
                {
                    // 捕獲銃を発射
                    FireCaptureGun();
                }
            }
            else
            {
                //第一引数に生成するオブジェクト、第二引数にVector3型の座標、第三引数に回転の情報
                Instantiate(lazer, attackPoint.position, Quaternion.identity);
                canAttack = false;　//攻撃フラグをfalseにする
                attackTime = 0f;　//attackTimeを0に戻す
            }
            canAttack = false;　//攻撃フラグをfalseにする
            attackTime = 0f;　//attackTimeを0に戻す
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    void SwitchWeapon(int newIndex)
    {
        // すべての武器を非アクティブにする
        foreach (GameObject weapon in CaptureGun)
        {
            weapon.SetActive(false);
        }

        // 新しい武器をアクティブにする
        CaptureGun[newIndex].SetActive(true);

        // 現在の武器インデックスを更新
        currentWeaponIndex = newIndex;
    }
    void FireCaptureGun()
    {
        //第一引数に生成するオブジェクト、第二引数にVector3型の座標、第三引数に回転の情報
        Instantiate(CaptureGun1, attackPoint.position, Quaternion.identity);
        canAttack = false; //攻撃フラグをfalseにする
        attackTime = 0f;　//attackTimeを0に戻す
    }
}