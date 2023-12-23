using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private SpriteRenderer spriteRenderer;

   

    [HideInInspector] public bool rightFacing;//�����Ă����(true,�E����,false,������)

    [HideInInspector] public float Speed;
    public CameraController cameraController; // �J��������N���X   

    // Start is called before the first frame update
    void Start()
    {
        //�R���|�[�l���g���擾
        rigidbody2D = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        rightFacing = true;//�ŏ��͉E����

        // �J���������ʒu
        cameraController.SetPosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
        // �W�����v���͏���
        JumpUpdate();
        // �J�����Ɏ��g�̍��W��n��
        cameraController.SetPosition(transform.position);
    }
   
    private void MoveUpdate()
    {
        //���̈ړ�����
        if (Input.GetKey(KeyCode.D))
        {//�E�����̈ړ�����
            //X�����ړ����x���v���X�ɐݒ�
            Speed = 6.0f;
            //�E�����t���Oon
            rightFacing = true;
            //�X�v���C�g��ʏ�̌����ŕ\��
            spriteRenderer.flipX = false;
        }
        //���̈ړ�����
        if (Input.GetKey(KeyCode.A))
        {//�������̈ړ�����
            //X�����ړ����x���}�C�i�X�ɐݒ�
            Speed = -6.0f;
            //�E�����t���Ooff
            rightFacing = false;
            //�X�v���C�g�����E���]���������ŕ\��
            spriteRenderer.flipX = true;
        }
        else
        {//���͂Ȃ�
            //X�����̈ړ���~
            Speed = 0.0f;
        }
      
    }
    /// <summary>
	/// Update����Ăяo�����W�����v���͏���
	/// </summary>
	private void JumpUpdate()
    {
        // �W�����v����
        if (Input.GetKeyDown(KeyCode.W))
        {// �W�����v�J�n
         // �W�����v�͂��v�Z
            float jumpPower = 10.0f;
            // �W�����v�͂�K�p
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpPower);
        }
    }
    private void FixedUpdate()
    {
        //�ړ����x�x�N�g�����ݒn���擾
        Vector2 velocity = rigidbody2D.velocity;
        //X�����̑��x���͂��猈��
        velocity.x = Speed;
        //�v�Z�����ړ����x�x�N�g����Rigidbody2D�ɔ��f
        rigidbody2D.velocity = velocity;
    }
}