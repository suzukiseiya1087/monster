using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���C���J��������N���X(Main Camera�ɃA�^�b�`)
/// </summary>
public class CameraController : MonoBehaviour
{
    // �I�u�W�F�N�g�E�R���|�[�l���g

    // �e��ϐ�
    private Vector2 basePos; // ��_���W

    /// <summary>
    /// �J�����̈ʒu�𓮂���
    /// </summary>
    /// <param name="targetPos">���W</param>
    public void SetPosition(Vector2 targetPos)
    {
        basePos = targetPos;
    }

    // FixedUpdate
    private void FixedUpdate()
    {
        // �J�����ړ�
        Vector3 pos = transform.localPosition;
        // �A�N�^�[�̌��݈ʒu��菭���E����f���悤��X�EY���W��␳
        pos.x = basePos.x + 2.5f; // X���W
        pos.y = basePos.y + 1.5f; // Y���W
                                  // Z���W�͌��ݒl(transform.localPosition)�����̂܂܎g�p

        // �v�Z��̃J�������W�𔽉f
        transform.localPosition = Vector3.Lerp(transform.localPosition, pos, 0.08f);
    }
}