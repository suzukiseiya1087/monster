using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���t�g�̏㉺
/// </summary>
public class LiftGimmick : MonoBehaviour
{

    public class Elevator : MonoBehaviour
    {
        private Transform targetPosition1; // �㏸����ʒu
        private Transform targetPosition2; // ���~����ʒu
        [SerializeField] float speed = 2.0f; // �G���x�[�^�[�̑���
        private float waitingTime = 2.0f; // ���t�g���ҋ@���鎞��

        private bool isMoving = false;

        void Start()
        {
            
            StartCoroutine(MoveElevator());
        }

        IEnumerator MoveElevator()
        {
            while (true)
            {
                yield return StartCoroutine(MoveToPosition(targetPosition1.position)); // �㏸
                yield return new WaitForSeconds(waitingTime);
                yield return StartCoroutine(MoveToPosition(targetPosition2.position)); // ���~
                yield return new WaitForSeconds(waitingTime);
            }
        }

        IEnumerator MoveToPosition(Vector3 target)
        {
            isMoving = true;
            while (transform.position != target)
            {
                transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
                yield return null;
            }
            isMoving = false;
        }
    }
}
