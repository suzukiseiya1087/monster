using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    //private SpriteRenderer spriteRenderer;

    //[SerializeField] float speed, dashspeed;



    public CameraController cameraController; // �J��������N���X   

    private float Speed = 0.05f;
    //float currentspeed;
    // Start is called before the first frame update
    void Start()
    {
        //currentspeed = Speed;
   



        // �J���������ʒu
        cameraController.SetPosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
    
        // �J�����Ɏ��g�̍��W��n��
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
    /// <summary>
	/// Update����Ăяo�����W�����v���͏���
	/// </summar

}