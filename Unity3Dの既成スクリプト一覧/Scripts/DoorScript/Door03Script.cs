using UnityEngine;
using UnityEngine.InputSystem;

public class Door03Script : MonoBehaviour
{
    private Animator animator;  // Animator���Q��
    private @InputController inputController;  // InputController���Q��
    private bool isPlayerNearby = false;  // �v���C���[���߂��ɂ��邩��ǐՂ���t���O

    public RuntimeAnimatorController doorAnimatorController; // �ǉ�: �A�j���[�^�[�R���g���[���[�̎Q��

    private void Awake()
    {
        inputController = new @InputController();  // InputController���C���X�^���X��
        animator = GetComponentInParent<Animator>();  // �e�I�u�W�F�N�g����Animator���擾
        animator.runtimeAnimatorController = doorAnimatorController;  // �e�I�u�W�F�N�g��RoomDoor02�A�j���[�^�[�R���g���[���[��ݒ�
    }

    private void OnEnable()
    {
        inputController.Enable();  // ���͂�L����
        inputController.Player.Take.performed += HandleDoorInput;  // Take�A�N�V���������s���ꂽ�Ƃ��̏�����ǉ�
    }

    private void OnDisable()
    {
        inputController.Disable();  // ���͂𖳌���
        inputController.Player.Take.performed -= HandleDoorInput;  // �C�x���g�n���h��������
    }

    private void HandleDoorInput(InputAction.CallbackContext context)
    {
        if (isPlayerNearby)  // �v���C���[���߂��ɂ���ꍇ�̂݊J����
        {
            bool isOpen = animator.GetBool("OpenAnim03");  // "OpenAnim03" �Ƃ����p�����[�^�[���擾
            animator.SetBool("OpenAnim03", !isOpen);  // OpenAnim03�p�����[�^�[�𔽓]�����ăh�A���J����/����
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // �v���C���[��SearchArea�ɓ�������
        {
            isPlayerNearby = true;  // �t���O�𗧂Ă�
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // �v���C���[��SearchArea���痣�ꂽ��
        {
            isPlayerNearby = false;  // �t���O������
        }
    }
}