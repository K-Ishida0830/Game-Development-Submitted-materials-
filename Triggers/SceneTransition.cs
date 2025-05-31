using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("遷移先のシーン名を入力")]
    [SerializeField]
    private string sceneToLoad;  // ← インスペクターでシーン名を設定可能

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!string.IsNullOrEmpty(sceneToLoad))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.LogWarning("SceneTransition: 遷移先のシーン名が設定されていません。");
            }
        }
    }
}
