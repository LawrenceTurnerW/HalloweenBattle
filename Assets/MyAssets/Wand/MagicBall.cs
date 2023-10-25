using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 発射されるかぼちゃ
public class MagicBall : MonoBehaviour
{
    private void Start()
    {
        // TODO：生成して暫くしたら球を削除する
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 衝突したオブジェクトがおばけだった場合
        // TODO:Conatainsで検索するのを修正する
        if (collision.gameObject.name.Contains("ghost"))
        {
            // まずおばけを削除
            Destroy(collision.gameObject);

            //その後自身を削除
            Destroy(this.gameObject);
        }
    }
}