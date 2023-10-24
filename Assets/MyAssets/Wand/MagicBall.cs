using UnityEngine;

// 発射される魔法球
public class MagicBall : MonoBehaviour
{
    // 魔法の球の速度
    [SerializeField]
    private float m_Speed = 20f;

    private void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();  // rigidbodyを取得
        Vector3 force = new Vector3(0.0f, 0.1f, 0.1f);  // 力を設定
        rb.AddForce(force, ForceMode.Impulse);          // 力を加える
        //1Fごとに弾を前に進ませる
        //transform.position += transform.forward * m_Speed * Time.deltaTime;
    }
}