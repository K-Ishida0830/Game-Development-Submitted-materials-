using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition02 : MonoBehaviour
{
    [Header("�ڐG������J�ڂ��鑊��I�u�W�F�N�g")]
    [SerializeField]
    private GameObject targetObject;  // �ڐG�Ώ�

    [Header("�J�ڐ�̃V�[����")]
    [SerializeField]
    private string sceneToLoad;       // �J�ڐ�V�[����

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
                Debug.LogWarning("SceneTransition: �J�ڐ�̃V�[�������ݒ肳��Ă��܂���B");
            }
        }
    }
}
