using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private int currentWeaponIndex = 0;
    public GameObject[] CaptureGun; // ����̔z��
    [SerializeField] private GameObject lazer; //���[�U�[�v���n�u���i�[
    [SerializeField] private GameObject CaptureGun1;
    [SerializeField] private Transform attackPoint;//�A�^�b�N�|�C���g���i�[

    [SerializeField] private float attackTime = 0.02f; //�U���̊Ԋu
    private float currentAttackTime; //�U���̊Ԋu���Ǘ�
    private bool canAttack; //�U���\��Ԃ����w�肷��t���O


    public CameraController cameraController; // �J��������N���X   

    private float Speed = 0.01f;
    //float currentspeed;
    // Start is called before the first frame update
    void Start()
    {
        //currentspeed = Speed;
        // �����̕����L���ɂ���
        SwitchWeapon(currentWeaponIndex);
        currentAttackTime = attackTime; //currentAttackTime��attackTime���Z�b�g�B


        // �J���������ʒu
        cameraController.SetPosition(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        MoveUpdate();
        // ����̐؂�ւ�����
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchWeapon((currentWeaponIndex + 1) % CaptureGun.Length);
        }
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
        if (Input.GetKey(KeyCode.D))
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
               if(currentWeaponIndex ==1)
                {
                    // �ߊl�e�𔭎�
                    FireCaptureGun();
                }
            }
            else
            {
                //�������ɐ�������I�u�W�F�N�g�A��������Vector3�^�̍��W�A��O�����ɉ�]�̏��
                Instantiate(lazer, attackPoint.position, Quaternion.identity);
                canAttack = false;�@//�U���t���O��false�ɂ���
                attackTime = 0f;�@//attackTime��0�ɖ߂�
            }
            canAttack = false;�@//�U���t���O��false�ɂ���
            attackTime = 0f;�@//attackTime��0�ɖ߂�
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    void SwitchWeapon(int newIndex)
    {
        // ���ׂĂ̕�����A�N�e�B�u�ɂ���
        foreach (GameObject weapon in CaptureGun)
        {
            weapon.SetActive(false);
        }

        // �V����������A�N�e�B�u�ɂ���
        CaptureGun[newIndex].SetActive(true);

        // ���݂̕���C���f�b�N�X���X�V
        currentWeaponIndex = newIndex;
    }
    void FireCaptureGun()
    {
        //�������ɐ�������I�u�W�F�N�g�A��������Vector3�^�̍��W�A��O�����ɉ�]�̏��
        Instantiate(CaptureGun1, attackPoint.position, Quaternion.identity);
        canAttack = false; //�U���t���O��false�ɂ���
        attackTime = 0f;�@//attackTime��0�ɖ߂�
    }
}