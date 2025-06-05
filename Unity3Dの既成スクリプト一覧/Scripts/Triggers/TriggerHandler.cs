using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public GameObject ghostWalkingObject; // GhostWalking�I�u�W�F�N�g���C���X�y�N�^�[�ŃZ�b�g
    private Animator ghostWalkingAnimator; // Animator�R���|�[�l���g

    void Start()
    {
        // GhostWalking�I�u�W�F�N�g��Animator�R���|�[�l���g���擾
        if (ghostWalkingObject != null)
        {
            ghostWalkingAnimator = ghostWalkingObject.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("GhostWalking�I�u�W�F�N�g���ݒ肳��Ă��܂���I");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // �v���C���[���g���K�[�ɐG�ꂽ�ꍇ
        {
            PlayStandbyAnimation(); // GhostWalking1�A�j���[�^�[��Standby�A�j���[�V�������쓮������
        }
    }

    void PlayStandbyAnimation()
    {
        if (ghostWalkingAnimator != null)
        {
            // "Standby" �A�j���[�V�������Đ�
            ghostWalkingAnimator.Play("Standby");
        }
    }
}
