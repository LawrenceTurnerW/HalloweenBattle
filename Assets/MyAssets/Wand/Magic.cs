using UnityEngine;

public class Magic : MonoBehaviour
{
    // ここで指定したオブジェクトの位置や角度を基準にする
    [SerializeField] private GameObject launchPoint;

    // 入力ボタンフィールをを作成できる
    [SerializeField] private OVRInput.RawButton inputBtn;

    // 生成するオブジェクト
    [SerializeField] private GameObject shot;

    private void Update()
    {
        // 指定したボタンが押されたら
        if (OVRInput.GetDown(inputBtn))
        {
            // かぼちゃをcontrolPointの位置と角度に合わせて生成する
            GameObject _pumpkin = Instantiate(shot, launchPoint.transform.position, launchPoint.transform.rotation);

            Rigidbody rb = _pumpkin.GetComponent<Rigidbody>();// rigidbodyを取得
            rb.AddForce(_pumpkin.transform.forward * 10f, ForceMode.Impulse);// 前方に力を加える
        }
    }
}