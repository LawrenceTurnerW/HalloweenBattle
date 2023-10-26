using UnityEngine;
using System.Collections;
public class ghostCount : MonoBehaviour
{
    // 発射地点
    [SerializeField] private GameObject centerEye;

    // 間隔
    [SerializeField] private float span = 3f;

    // おばけ
    [SerializeField] private GameObject ghost;

    void Start()
    {
        StartCoroutine("Logging");
    }

    IEnumerator Logging()
    {
        while (true)
        {
            yield return new WaitForSeconds(span);
            GameObject[] ghosts = GameObject.FindGameObjectsWithTag("ghost");

            Vector3 playerPos = centerEye.transform.position;

            foreach (GameObject ghost in ghosts)
            {
                float dis = Vector3.Distance(ghost.transform.position, playerPos);
                // 10m以上は多分メッシュ貫通してどっか行ってるのでおばけを消す
                if (dis > 10)
                {
                    Destroy(ghost);
                }
            }
            int rnd = Random.Range(-10, 10);
            if (ghosts.Length < 10)
            {
                GameObject _newGhost = Instantiate(ghost, playerPos, Quaternion.identity);
                Rigidbody rb = _newGhost.GetComponent<Rigidbody>();
                rb.AddForce(new Vector3(rnd, rnd, rnd) * 50, ForceMode.Force);
            }
        }
    }
}