using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition02 : MonoBehaviour
{
    [Header("接触したら遷移する相手オブジェクト")]
    [SerializeField]
    private GameObject targetObject;  // 接触対象

    [Header("遷移先のシーン名")]
    [SerializeField]
    private string sceneToLoad;       // 遷移先シーン名

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == targetObject)
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
