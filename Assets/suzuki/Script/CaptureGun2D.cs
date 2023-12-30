using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureGun2D : MonoBehaviour
{
    public float captureRange = 5f;
    public LayerMask captureLayer;

    void Update()
    {
        if (Input.GetKey(KeyCode.M))
        {
            Capture();
        }
    }

    void Capture()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePosition, captureRange, captureLayer);

        foreach (Collider2D collider in colliders)
        {
            // キャプチャー成功時の処理
            GameObject capturedObject = collider.gameObject;
            Debug.Log("Captured: " + capturedObject.name);

            // ここにキャプチャー後の処理を追加
            Destroy(capturedObject); // 例：敵を削除する
        }
    }
}
