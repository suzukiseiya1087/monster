using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// リフトの上下
/// </summary>
public class LiftGimmick : MonoBehaviour
{

    public class Elevator : MonoBehaviour
    {
        private Transform targetPosition1; // 上昇する位置
        private Transform targetPosition2; // 下降する位置
        [SerializeField] float speed = 2.0f; // エレベーターの速さ
        private float waitingTime = 2.0f; // リフトが待機する時間

        private bool isMoving = false;

        void Start()
        {
            
            StartCoroutine(MoveElevator());
        }

        IEnumerator MoveElevator()
        {
            while (true)
            {
                yield return StartCoroutine(MoveToPosition(targetPosition1.position)); // 上昇
                yield return new WaitForSeconds(waitingTime);
                yield return StartCoroutine(MoveToPosition(targetPosition2.position)); // 下降
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
