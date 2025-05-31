using UnityEngine;

public class EntranceTrigger : MonoBehaviour
{
    public GameObject trigger01; // Trigger01�̃I�u�W�F�N�g
    private bool isActivated = false; // Trigger01���L�������ꂽ���ǂ���

    private void Start()
    {
        // ������Ԃł�Trigger01�𖳌���
        if (trigger01 != null)
        {
            trigger01.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �v���C���[���ڐG�����ꍇ
        {
            if (!isActivated && trigger01 != null)
            {
                trigger01.SetActive(true); // Trigger01��L����
                isActivated = true;
            }
        }
    }
}
