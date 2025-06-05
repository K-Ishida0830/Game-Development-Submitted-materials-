using UnityEngine;
using UnityEngine.SceneManagement; // �V�[���J�ڂ̂��߂ɕK�v

public class GameOver : MonoBehaviour
{
    // �Փˎ��ɃQ�[���I�[�o�[�������s��
    private void OnTriggerEnter(Collider other)
    {
        // �Փ˂����I�u�W�F�N�g���S�[�X�g�ł���ꍇ
        if (other.gameObject.CompareTag("Ghost"))
        {
            Debug.Log("�S�[�X�g�ƏՓ˂��܂����I");
            GameOverScene();  // �Q�[���I�[�o�[�V�[���֑J��
        }
    }

    // �Q�[���I�[�o�[�V�[���ւ̈ڍs
    private void GameOverScene()
    {
        Debug.Log("�Q�[���I�[�o�[�V�[���֑J�ڂ��܂�...");
        SceneManager.LoadScene("Game Over"); // "Game Over"�V�[���ւ̑J��
    }
}
