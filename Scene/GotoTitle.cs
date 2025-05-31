using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class GotoTitle : MonoBehaviour
{
    public Button retryButton;  // ���g���C�{�^��
    public Button exitButton;   // Exit�{�^��
    private bool isButtonPressed = false;  // �Q�[���p�b�h��L�[�{�[�h�������ꂽ���ǂ���
    public string titleSceneName = "Title";  // �^�C�g���ɑJ�ڂ���V�[����

    void Start()
    {
        // �{�^���̃N���b�N�C�x���g�Ƀ��\�b�h��R�t����
        retryButton.onClick.AddListener(() => LoadScene("Scene01")); // ���g���C
        exitButton.onClick.AddListener(() => LoadScene(titleSceneName)); // Exit
    }

    void Update()
    {
        // �Q�[���p�b�h��A�{�^���������ꂽ���m�F
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)  // A�{�^���ɑΉ�
        {
            // ���ݑI������Ă���{�^�����Q�[���p�b�h�ŉ����ꂽ�{�^���ƈ�v���邩�m�F
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                Button selectedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
                if (selectedButton != null && selectedButton.interactable)
                {
                    // �I������Ă���{�^���̃N���b�N�C�x���g���Ăяo��
                    selectedButton.onClick.Invoke();
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
