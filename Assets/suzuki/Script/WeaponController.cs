using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    // （復習）
    // 「配列」について復習しましょう！
    public GameObject[] weapons;
    public GameObject[] shotWeapons;
    public AudioClip changeSound;
    public int currentNum = 0;
    public GameObject aimObject;


    void Start()
    {

        // 「for文」の「意味」と「使い方」を復習しましょう。
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

        // もしも「右クリック」を押した場合には、
        if (Input.GetMouseButtonDown(1))
        {
            AudioSource.PlayClipAtPoint(changeSound, Camera.main.transform.position);

            // （重要テクニック）
            // 配列の中の順序を１つずつ繰り上げていくテクニック
            // 実際に「currentNum」の箱に中に入る数字がどう変化するか書き出してみましょう。
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


        // もしも「左クリック」を押した場合には、
        if (Input.GetMouseButton(0))
        {
            // 照準器を表示する。
            aimObject.SetActive(true);

            // 現在選択しているメインカメラモードの武器が非表示（オフ）になる。
            weapons[currentNum].SetActive(false);

            // 現在選択しているサブカメラモードの武器が表示（オン）になる。
            shotWeapons[currentNum].SetActive(true);

        }
        else
        {
            // 照準器を非表示にする。
            aimObject.SetActive(false);

            // 現在選択しているメインカメラモードの武器が表示（オン）になる。
            weapons[currentNum].SetActive(true);

            // 現在選択しているサブカメラモードの武器が非表示（オフ）になる。
            shotWeapons[currentNum].SetActive(false);

        }
    }
}