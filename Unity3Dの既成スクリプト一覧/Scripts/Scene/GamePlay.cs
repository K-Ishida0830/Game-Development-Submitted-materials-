using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;  // EventSystem��ǉ�

public class GamePlay : MonoBehaviour
{
    public Button startButton;  // �{�^�����C���X�y�N�^�[�ŃA�^�b�`����
    public Button retryButton;  // ���g���C�{�^����ǉ�
    private bool isButtonPressed = false;  // �Q�[���p�b�h��L�[�{�[�h�������ꂽ���ǂ���
    public string startSceneName = "Scene01";  // ���g���C���ɑJ�ڂ���V�[����
    public string titleSceneName = "Title";  // �^�C�g���ɑJ�ڂ���V�[����

    void Start()
    {
        // �{�^���̃N���b�N�C�x���g�Ƀ��\�b�h��R�t����
        if (startButton != null)
            startButton.onClick.AddListener(() => LoadScene(startSceneName));

        if (retryButton != null)
            retryButton.onClick.AddListener(() => LoadScene(startSceneName)); // ���g���C�{�^�����ǉ�
    }

    void Update()
    {
        // �Q�[���p�b�h��A�{�^���������ꂽ���m�F
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)  // A�{�^���ɑΉ�
        {
            // ���ݑI������Ă���{�^�����Q�[���p�b�h�ŉ����ꂽ�{�^���ƈ�v���邩�m�F
            if (EventSystem.current != null && EventSystem.current.currentSelectedGameObject != null)
            {
                Button selectedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
                if (selectedButton != null && selectedButton.interactable)
                {
                    selectedButton.onClick.Invoke();  // �I������Ă���{�^���̃N���b�N�C�x���g���Ăяo��
                    isButtonPressed = true;  // �{�^���������ꂽ���Ƃ��L�^
                }
            }
        }
        else
        {
            isButtonPressed = false;  // �Q�[���p�b�h�������ꂽ�烊�Z�b�g
        }
    }

    // �V�[����J�ڂ��郁�\�b�h
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
