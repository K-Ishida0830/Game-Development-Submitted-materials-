using UnityEngine;

public class Trigger05 : MonoBehaviour
{
    public GameObject targetObject;  // 有効にしたいオブジェクト

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // "Player"タグのオブジェクトが触れたら
        {
            if (targetObject != null)
            {
                targetObject.SetActive(true);
            }
        }
    }
}
