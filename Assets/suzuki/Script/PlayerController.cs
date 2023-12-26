using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    [SerializeField] private GameObject lazer; //���[�U�[�v���n�u���i�[
    [SerializeField] private Transform attackPoint;//�A�^�b�N�|�C���g���i�[

    [SerializeField] private float attackTime = 0.2f; //�U���̊Ԋu
    private float currentAttackTime; //�U���̊Ԋu���Ǘ�
    private bool canAttack; //�U���\��Ԃ����w�肷��t���O


    public CameraController cameraController; // �J��������N���X   

    private float Speed = 0.05f;
    //float currentspeed;
    // Start is called before the first frame update
    void Start()
    {
        //currentspeed = Speed;

        currentAttackTime = attackTime; //currentAttackTime��attackTime���Z�b�g�B


        // �J���������ʒu
        cameraController.SetPosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();

        //~�ȗ�~
        Attack();
        // �J�����Ɏ��g�̍��W��n��
        cameraController.SetPosition(transform.position);
    }

    private void MoveUpdate()
    {
        Vector2 position = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            position.x -= Speed;
        }
        if (Input.GetKey(KeyCode.W))
        {
            position.x += Speed;
        }
        transform.position = position;
    }
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

        if (Input.GetKeyDown(KeyCode.Z)) //K�L�[����������
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