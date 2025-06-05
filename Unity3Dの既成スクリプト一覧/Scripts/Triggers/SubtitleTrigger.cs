using UnityEngine;

public class SubtitleTrigger : MonoBehaviour
{
    public GameObject subtitleParent; // �u�����R�v�I�u�W�F�N�g
    public float displayTime = 5f; // �\�����ԁi�b�j
    private bool hasTriggered = false; // ���łɎ�����\���������ǂ����̃t���O

    private void Awake()
    {
        if (subtitleParent != null)
        {
            subtitleParent.SetActive(false); // �Q�[���J�n���ɔ�\��
        }
        else
        {
            Debug.LogError("�����R�̃I�u�W�F�N�g���ݒ肳��Ă��܂���I");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player")) // �܂��\�����Ă��Ȃ��ꍇ�̂�
        {
            ShowSubtitle();
        }
    }

    void ShowSubtitle()
    {
        if (subtitleParent != null)
        {
            subtitleParent.SetActive(true); // �����R��\��
            Invoke("HideSubtitle", displayTime); // 5�b��ɔ�\��
            hasTriggered = true; // 1�x�����\��
        }
    }

    void HideSubtitle()
    {
        if (subtitleParent != null)
        {
            subtitleParent.SetActive(false); // �����R���\��
        }
    }
}
