using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;







    public CameraController cameraController; // カメラ制御クラス   

    private float Speed =0.05f;
    //float currentspeed;
    // Start is called before the first frame update
    void Start()
    {
        //currentspeed = Speed;

       

        // カメラ初期位置
        cameraController.SetPosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
       
        // カメラに自身の座標を渡す
        cameraController.SetPosition(transform.position);
    }
   
    private void MoveUpdate()
    {
        Vector2 position = transform.position;
        if(Input.GetKey(KeyCode.A))
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
	/// </summary>
	
  
}