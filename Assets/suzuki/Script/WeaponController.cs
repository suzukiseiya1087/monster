using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // �i���K�j
    // �u�z��v�ɂ��ĕ��K���܂��傤�I
    public GameObject[] weapons;
    public GameObject[] shotWeapons;
    public AudioClip changeSound;
    public int currentNum = 0;
    public GameObject aimObject;


    void Start()
    {

        // �ufor���v�́u�Ӗ��v�Ɓu�g�����v�𕜏K���܂��傤�B
        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == currentNum)
            {
                weapons[i].SetActive(true);
            }
            else
            {
                weapons[i].SetActive(false);
            }
        }

        for (int i = 0; i < shotWeapons.Length; i++)
        {
            if (i == currentNum)
            {
                shotWeapons[i].SetActive(true);
            }
            else
            {
                shotWeapons[i].SetActive(false);
            }
        }
    }

    void Update()
    {

        // �������u�E�N���b�N�v���������ꍇ�ɂ́A
        if (Input.GetMouseButtonDown(1))
        {
            AudioSource.PlayClipAtPoint(changeSound, Camera.main.transform.position);

            // �i�d�v�e�N�j�b�N�j
            // �z��̒��̏������P���J��グ�Ă����e�N�j�b�N
            // ���ۂɁucurrentNum�v�̔��ɒ��ɓ��鐔�����ǂ��ω����邩�����o���Ă݂܂��傤�B
            currentNum = (currentNum + 1) % weapons.Length;

            for (int i = 0; i < weapons.Length; i++)
            {
                if (i == currentNum)
                {
                    weapons[i].SetActive(true);
                }
                else
                {
                    weapons[i].SetActive(false);
                }
            }

            for (int i = 0; i < shotWeapons.Length; i++)
            {
                if (i == currentNum)
                {
                    shotWeapons[i].SetActive(true);
                }
                else
                {
                    shotWeapons[i].SetActive(false);
                }
            }
        }


        // �������u���N���b�N�v���������ꍇ�ɂ́A
        if (Input.GetMouseButton(0))
        {
            // �Ə����\������B
            aimObject.SetActive(true);

            // ���ݑI�����Ă��郁�C���J�������[�h�̕��킪��\���i�I�t�j�ɂȂ�B
            weapons[currentNum].SetActive(false);

            // ���ݑI�����Ă���T�u�J�������[�h�̕��킪�\���i�I���j�ɂȂ�B
            shotWeapons[currentNum].SetActive(true);

        }
        else
        {
            // �Ə�����\���ɂ���B
            aimObject.SetActive(false);

            // ���ݑI�����Ă��郁�C���J�������[�h�̕��킪�\���i�I���j�ɂȂ�B
            weapons[currentNum].SetActive(true);

            // ���ݑI�����Ă���T�u�J�������[�h�̕��킪��\���i�I�t�j�ɂȂ�B
            shotWeapons[currentNum].SetActive(false);

        }
    }
}