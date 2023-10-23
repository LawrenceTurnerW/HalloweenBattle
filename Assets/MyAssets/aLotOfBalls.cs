using UnityEngine;

public class TestScript : MonoBehaviour
{
    // ここで指定したオブジェクトの位置や角度を基準にする
    [SerializeField] private GameObject controlPoint;

    // 入力ボタンフィールをを作成できる
    [SerializeField] private OVRInput.RawButton inputBtn;

    // 生成するオブジェクト
    [SerializeField] private GameObject ball;

    private void Update()
    {
        // 指定したボタンが押されたら
        if (OVRInput.GetDown(inputBtn))
        {
            for (int i = 0; i < 10; i++)
            {
                // ballをcontrolPointの位置と角度に合わせて生成する
                Instantiate(ball, controlPoint.transform.position, Quaternion.identity);
            }
        }
    }
}