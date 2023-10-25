using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// 発射されるかぼちゃ
public class MagicBall : MonoBehaviour
{
    // 生成するお菓子オブジェクト
    [SerializeField] private GameObject sweet1;
    [SerializeField] private GameObject sweet2;
    [SerializeField] private GameObject sweet3;
    [SerializeField] private GameObject sweet4;
    [SerializeField] private GameObject sweet5;
    [SerializeField] private GameObject sweet6;

    // 笑い声を生成するオブジェクト
    [SerializeField] private GameObject witchsLaughter;

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
            // 魔女の笑い声を生成
            GameObject s_laugh = Instantiate(witchsLaughter, this.transform.position, this.transform.rotation);
            Destroy(s_laugh.gameObject, 3f);

            CreateSweet(sweet1);
            CreateSweet(sweet2);
            CreateSweet(sweet3);
            CreateSweet(sweet4);
            CreateSweet(sweet5);
            CreateSweet(sweet6);
            // おばけを削除
            Destroy(collision.gameObject);

            //その後自身を削除
            Destroy(this.gameObject);
        }
    }


    private void CreateSweet(GameObject sweet)
    {
        //スイーツを生成
        GameObject _sweet = Instantiate(sweet, this.transform.position, this.transform.rotation);

        // ランダムな方向に力をかけて跳ねさせる
        float rnd = Random.Range(-3, 3);

        Rigidbody rb = _sweet.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(rnd, Mathf.Abs(rnd) * 3, rnd), ForceMode.Impulse);// 上方向には跳ねてほしいので絶対値をかけた上で値を大きくする

        //その3秒後に自身を削除
        Destroy(_sweet.gameObject, 3f);
    }
}
