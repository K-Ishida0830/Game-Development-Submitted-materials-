using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Triggerとして衝突を検出
    void OnTriggerEnter(Collider other)
    {
        // 衝突したオブジェクトがゴーストである場合
        if (other.gameObject.CompareTag("Ghost"))
        {
            // ゲームオーバー処理
            Debug.Log("ゴーストと接触した！ゲームオーバー");
            GameOver();
        }
    }

    // ゲームオーバーシーンに遷移
    void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
