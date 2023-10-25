using UnityEngine;

public class Magic : MonoBehaviour
{
    // ここで指定したオブジェクトの位置や角度を基準にする
    [SerializeField] private GameObject launchPoint;

    // 発射トリガー入力
    [SerializeField] private OVRInput.RawButton launchTrigger;

    // 強化入力トリガー
    [SerializeField] private OVRInput.RawButton powerTrigger;

    // 生成するオブジェクト
    [SerializeField] private GameObject shot;

    // かぼちゃ発射時の効果音
    [SerializeField] private AudioClip audioClip;
    private AudioSource audioSource;

    private void Update()
    {
        // 発射トリガーが押されたら
        if (OVRInput.GetDown(launchTrigger))
        {
            // 効果音を鳴らす
            audioSource = launchPoint.GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();

            // かぼちゃをcontrolPointの位置と角度に合わせて生成する
            GameObject _pumpkin = Instantiate(shot, launchPoint.transform.position, launchPoint.transform.rotation);

            float power = 5.0f;
            // もし強化入力が追加で行われていれば
            if (OVRInput.Get(powerTrigger))
            {
                power = power * 2;
            }
            Rigidbody rb = _pumpkin.GetComponent<Rigidbody>();// rigidbodyを取得
            rb.AddForce(_pumpkin.transform.forward * power, ForceMode.Impulse);// 前方に力を加える
        }
    }
}