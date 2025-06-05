using UnityEngine;

public class NoiseController : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransform
    public Transform ghost;   // ゴーストのTransform
    public CanvasGroup noiseCanvasGroup;  // ノイズのCanvasGroup
    public float maxDistance = 10f;  // ノイズの最大影響距離

    private bool isNoiseActive = false;  // ノイズが有効かどうか

    private void OnEnable()
    {
        ItemPickup.OnItemPickedUp += ActivateNoise;
    }

    private void OnDisable()
    {
        ItemPickup.OnItemPickedUp -= ActivateNoise;
    }

    private void ActivateNoise()
    {
        isNoiseActive = true;
        Debug.Log("Noise Activated!"); // デバッグ用
    }

    void Update()
    {
        if (!isNoiseActive)
        {
            noiseCanvasGroup.alpha = 0;  // ノイズを非表示
            return;
        }

        // プレイヤーとゴーストの位置を取得
        Vector3 playerPos = player.position;
        Vector3 ghostPos = ghost.position;

        // 3D空間での距離を計算
        float distance = Vector3.Distance(playerPos, ghostPos);

        // デバッグログ
        Debug.Log($"Player Pos: {playerPos}, Ghost Pos: {ghostPos}, Distance: {distance}");

        // 透明度を計算 (距離が `maxDistance` 以上なら alpha = 0, 近づくほど alpha = 1)
        float alpha = Mathf.Clamp01(1 - (distance / maxDistance));

        // 透明度をスムーズに変更
        noiseCanvasGroup.alpha = Mathf.Lerp(noiseCanvasGroup.alpha, alpha, Time.deltaTime * 5f);

        // 透明度のデバッグログ
        Debug.Log($"Calculated Alpha: {alpha}");
    }
}
