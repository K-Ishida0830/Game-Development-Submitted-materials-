using UnityEngine;
using UnityEngine.Playables;

public class NoiseTrigger : MonoBehaviour
{
    [Header("�ڐG�Ώۂ̃I�u�W�F�N�g")]
    public GameObject targetObject;  // �C���X�y�N�^�[�Ŏw��

    [Header("�Đ�����Timeline")]
    public PlayableDirector timeline;

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.gameObject == targetObject)
        {
            if (timeline != null)
            {
                timeline.Play();
                hasTriggered = true;
            }
            else
            {
                Debug.LogWarning("Timeline ���w�肳��Ă��܂���I");
            }
        }
    }
}
