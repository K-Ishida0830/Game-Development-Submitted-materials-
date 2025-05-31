using UnityEngine;
using UnityEngine.SceneManagement; // シーン遷移のために必要

public class GameOver : MonoBehaviour
{
    // 衝突時にゲームオーバー処理を行う
    private void OnTriggerEnter(Collider other)
    {
        // 衝突したオブジェクトがゴーストである場合
        if (other.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("ゴーストと衝突しました！");
            GameOverScene();  // ゲームオーバーシーンへ遷移
        }
    }

    // ゲームオーバーシーンへの移行
    private void GameOverScene()
    {
        Debug.Log("ゲームオーバーシーンへ遷移します...");
        SceneManager.LoadScene("Game Over"); // "Game Over"シーンへの遷移
    }
}
