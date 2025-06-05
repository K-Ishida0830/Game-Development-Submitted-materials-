using UnityEngine;

public class Trigger05 : MonoBehaviour
{
    public GameObject targetObject;  // �L���ɂ������I�u�W�F�N�g

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // "Player"�^�O�̃I�u�W�F�N�g���G�ꂽ��
        {
            if (targetObject != null)
            {
                targetObject.SetActive(true);
            }
        }
    }
}
