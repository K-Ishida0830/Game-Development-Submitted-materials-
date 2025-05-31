using UnityEngine;
using System.Collections;
using StarterAssets;

public class Trigger01 : MonoBehaviour
{
    public GameObject ghostWalking;
    public GameObject subtitle4;
    public Camera mainCamera;
    public Camera eventCamera;
    public GameObject player; // �v���C���[�I�u�W�F�N�g

    public GameObject objectToDisable; // �G�ꂽ�疳���ɂ���I�u�W�F�N�g
    public GameObject objectToEnable;  // �G�ꂽ��L���ɂ���I�u�W�F�N�g

    private Animator ghostAnimator;
    private bool isWaiting = false;
    private bool hasTriggered = false;
    private CharacterController playerController;
    private Rigidbody playerRigidbody;
    private ThirdPersonController thirdPersonController; // ThirdPersonController�Q�Ɨp

    private void Awake()
    {
        if (subtitle4 != null)
            subtitle4.SetActive(false);

        if (ghostWalking != null)
            ghostWalking.SetActive(false);

        if (eventCamera != null)
            eventCamera.enabled = false;

        // �v���C���[�̃R���|�[�l���g���擾
        if (player != null)
        {
            playerController = player.GetComponent<CharacterController>();
            playerRigidbody = player.GetComponent<Rigidbody>();
            thirdPersonController = player.GetComponent<ThirdPersonController>();
        }
    }

    private void Start()
    {
        if (ghostWalking != null)
            ghostWalking.SetActive(false);

        ghostAnimator = ghostWalking.GetComponent<Animator>();
    }

    private void Update()
    {
        if (ghostAnimator != null && !isWaiting)
        {
            AnimatorStateInfo stateInfo = ghostAnimator.GetCurrentAnimatorStateInfo(0);

            if (stateInfo.IsName("Pass by") && !ghostAnimator.IsInTransition(0) && stateInfo.normalizedTime >= 1.0f)
            {
                if (!isWaiting)
                {
                    ghostWalking.SetActive(false);
                    StartCoroutine(DisplayAndHideSubtitle());
                    isWaiting = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            ghostWalking.SetActive(true);
            ghostAnimator.SetBool("WalkingG", true);

            // �J�����؂�ւ�
            if (mainCamera != null && eventCamera != null)
            {
                mainCamera.enabled = false;
                eventCamera.enabled = true;
            }

            FreezePlayer();

            // �w��I�u�W�F�N�g�̗L��/�����؂�ւ�
            if (objectToDisable != null)
                objectToDisable.SetActive(false);

            if (objectToEnable != null)
                objectToEnable.SetActive(true);
        }
    }

    private IEnumerator DisplayAndHideSubtitle()
    {
        subtitle4.SetActive(true);
        yield return new WaitForSeconds(3f);
        subtitle4.SetActive(false);

        // �J�����߂� & �v���C���[���앜�A
        if (mainCamera != null && eventCamera != null)
        {
            eventCamera.enabled = false;
            mainCamera.enabled = true;
        }

        UnfreezePlayer();
    }

    private void FreezePlayer()
    {
        if (thirdPersonController != null)
        {
            thirdPersonController.enabled = false;
        }
    }

    private void UnfreezePlayer()
    {
        if (thirdPersonController != null)
        {
            thirdPersonController.enabled = true;
        }
    }
}
