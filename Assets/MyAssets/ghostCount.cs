using UnityEngine;

public class Timer : MonoBehaviour
{

    [SerializeField] private float span = 5f;

    void Start()
    {
        StartCoroutine("Logging");
    }

    IEnumerator Logging()
    {
        while (true)
        {
            yield return new WaitForSeconds(span);
            GameObject[] cubeObjects = GameObject.FindGameObjectsWithTag("Cube");
        }
    }
}