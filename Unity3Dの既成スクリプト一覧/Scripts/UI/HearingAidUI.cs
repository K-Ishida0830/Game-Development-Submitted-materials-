using UnityEngine;

public class HearingAidUI : MonoBehaviour
{
    void Start()
    {
        // 初期状態では非表示
        gameObject.SetActive(false);

        // アイテム取得イベントを登録
        ItemPickup.OnItemPickedUp += ShowUI;
    }

    void OnDestroy()
    {
        // イベント登録を解除
        ItemPickup.OnItemPickedUp -= ShowUI;
    }

    // UIを表示するメソッド
    private void ShowUI()
    {
        Debug.Log("補聴器のUIを表示します。");
        gameObject.SetActive(true); // UIを表示
    }
}