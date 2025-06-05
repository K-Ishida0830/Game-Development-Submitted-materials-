using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    // Trigger�Ƃ��ďՓ˂����o
    void OnTriggerEnter(Collider other)
    {
        // �Փ˂����I�u�W�F�N�g���S�[�X�g�ł���ꍇ
        if (other.gameObject.CompareTag("Ghost"))
        {
            // �Q�[���I�[�o�[����
            Debug.Log("�S�[�X�g�ƐڐG�����I�Q�[���I�[�o�[");
            GameOver();
        }
    }

    // �Q�[���I�[�o�[�V�[���ɑJ��
    void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
