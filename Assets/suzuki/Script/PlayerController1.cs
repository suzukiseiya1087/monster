using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField] private GameObject lazer; //���[�U�[�v���n�u���i�[
    [SerializeField] private Transform attackPoint;//�A�^�b�N�|�C���g���i�[

    [SerializeField] private float attackTime = 0.02f; //�U���̊Ԋu
    private float currentAttackTime; //�U���̊Ԋu���Ǘ�
    private bool canAttack; //�U���\��Ԃ����w�肷��t���O
   

    public CameraController cameraController; // �J��������N���X   

    private float Speed = 0.09f;
    //float currentspeed;
    // Start is called before the first frame update
    void Start()
    {
        //currentspeed = Speed;
        rigidbody2D = GetComponent<Rigidbody2D>(); // Rigidbody2D�R���|�[�l���g���擾
        currentAttackTime = attackTime; //currentAttackTime��attackTime���Z�b�g�B


        // �J���������ʒu
        cameraController.SetPosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
        // Check if W key is pressed and player has not exceeded the jump count
     
        //~�ȗ�~
        Attack();
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
	/// Update����Ăяo�����W�����v���͏���
	/// </summar
    void Attack()
    {
        attackTime += Time.deltaTime; //attackTime�ɖ��t���[���̎��Ԃ����Z���Ă���

        if (attackTime > currentAttackTime)
        {
            canAttack = true; //�w�莞�Ԃ𒴂�����U���\�ɂ���
        }

        if (Input.GetKeyDown(KeyCode.K)) //K�L�[����������
        {
            if (canAttack)
            {
                //�������ɐ�������I�u�W�F�N�g�A��������Vector3�^�̍��W�A��O�����ɉ�]�̏��
                Instantiate(lazer, attackPoint.position, Quaternion.identity);
                canAttack = false;�@//�U���t���O��false�ɂ���
                attackTime = 0f;�@//attackTime��0�ɖ߂�
            }
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}