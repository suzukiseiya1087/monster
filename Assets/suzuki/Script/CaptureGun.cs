using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureGun : MonoBehaviour
{
    [SerializeField] private float speed = 5; //�e�e�̃X�s�[�h

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();

    }

    public void Move()
    {
        Vector3 lazerPos = transform.position; //Vector3�^��playerPos�Ɍ��݂̈ʒu�����i�[
        lazerPos.x += speed * Time.deltaTime; //x���W��speed�����Z
        transform.position = lazerPos; //���݂̈ʒu���ɔ��f������
    }
}
