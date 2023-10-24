using UnityEngine;

public class Magic : MonoBehaviour
{
    // ここで指定したオブジェクトの位置や角度を基準にする
    [SerializeField] private GameObject launchPoint;

    // 入力ボタンフィールをを作成できる
    [SerializeField] private OVRInput.RawButton inputBtn;

    // 生成するオブジェクト
    [SerializeField] private GameObject ball;

    private void Update()
    {
        // 指定したボタンが押されたら
        if (true)//OVRInput.GetDown(inputBtn))
        {
            // 魔法の球をcontrolPointの位置と角度に合わせて生成する
            Instantiate(ball, launchPoint.transform.position, launchPoint.transform.rotation);
        }
    }
}