using UnityEngine;

public class SubtitleTrigger : MonoBehaviour
{
    public GameObject subtitleParent; // 「字幕３」オブジェクト
    public float displayTime = 5f; // 表示時間（秒）
    private bool hasTriggered = false; // すでに字幕を表示したかどうかのフラグ

    private void Awake()
    {
        if (subtitleParent != null)
        {
            subtitleParent.SetActive(false); // ゲーム開始時に非表示
        }
        else
        {
            Debug.LogError("字幕３のオブジェクトが設定されていません！");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player")) // まだ表示していない場合のみ
        {
            ShowSubtitle();
        }
    }

    void ShowSubtitle()
    {
        if (subtitleParent != null)
        {
            subtitleParent.SetActive(true); // 字幕３を表示
            Invoke("HideSubtitle", displayTime); // 5秒後に非表示
            hasTriggered = true; // 1度だけ表示
        }
    }

    void HideSubtitle()
    {
        if (subtitleParent != null)
        {
            subtitleParent.SetActive(false); // 字幕３を非表示
        }
    }
}
