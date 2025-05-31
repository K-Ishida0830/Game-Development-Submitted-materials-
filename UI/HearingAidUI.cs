using UnityEngine;

public class HearingAidUI : MonoBehaviour
{
    void Start()
    {
        // ������Ԃł͔�\��
        gameObject.SetActive(false);

        // �A�C�e���擾�C�x���g��o�^
        ItemPickup.OnItemPickedUp += ShowUI;
    }

    void OnDestroy()
    {
        // �C�x���g�o�^������
        ItemPickup.OnItemPickedUp -= ShowUI;
    }

    // UI��\�����郁�\�b�h
    private void ShowUI()
    {
        Debug.Log("�⒮���UI��\�����܂��B");
        gameObject.SetActive(true); // UI��\��
    }
}