using UnityEngine;

public class PlayAnimationOnTouch : MonoBehaviour
{
    [Tooltip("�Đ�������Ώۂ� Animator�i�O����w��j")]
    public Animator targetAnimator;

    [Tooltip("�Đ��g���K�[�ƂȂ� bool �p�����[�^��")]
    public string boolParameterName; // �R�[�h���Ŏw�肹���A�C���X�y�N�^�[����w��

    private bool hasPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            if (targetAnimator != null)
            {
                // �C���X�y�N�^�[�Ŏw�肳�ꂽ�p�����[�^�����g����bool�l��ύX
                targetAnimator.SetBool(boolParameterName, true);
                hasPlayed = true;
            }
            else
            {
                Debug.LogWarning("targetAnimator ���ݒ肳��Ă��܂���I");
            }
        }
    }
}