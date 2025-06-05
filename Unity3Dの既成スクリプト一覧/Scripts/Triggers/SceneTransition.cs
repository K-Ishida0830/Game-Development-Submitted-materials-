using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [Header("�J�ڐ�̃V�[���������")]
    [SerializeField]
    private string sceneToLoad;  // �� �C���X�y�N�^�[�ŃV�[������ݒ�\

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
                Debug.LogWarning("SceneTransition: �J�ڐ�̃V�[�������ݒ肳��Ă��܂���B");
            }
        }
    }
}
