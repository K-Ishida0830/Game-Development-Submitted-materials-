using UnityEngine;

public class EntranceTrigger : MonoBehaviour
{
    public GameObject trigger01; // Trigger01のオブジェクト
    private bool isActivated = false; // Trigger01が有効化されたかどうか

    private void Start()
    {
        // 初期状態ではTrigger01を無効化
        if (trigger01 != null)
        {
            trigger01.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // プレイヤーが接触した場合
        {
            if (!isActivated && trigger01 != null)
            {
                trigger01.SetActive(true); // Trigger01を有効化
                isActivated = true;
            }
        }
    }
}
