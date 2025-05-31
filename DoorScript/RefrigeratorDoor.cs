using UnityEngine;
using UnityEngine.InputSystem;

public class RefrigeratorDoor : MonoBehaviour
{
    private Animator animator;
    private @InputController inputController;
    private bool isPlayerNearby = false;

    private void Awake()
    {
        inputController = new @InputController();

        // �e�I�u�W�F�N�g�iRefrigerator2�j���� Animator ���擾
        Transform parent = transform.parent;  // `Refrigerator2`
        if (parent != null)
        {
            animator = parent.GetComponent<Animator>();
        }

        // Animator ��������Ȃ��ꍇ�̓G���[���b�Z�[�W���o��
        if (animator == null)
        {
            Debug.LogError("Animator �� Refrigerator2 �Ɍ�����܂���I", this);
        }
    }

    private void OnEnable()
    {
        inputController.Enable();
        inputController.Player.Take.performed += HandleDoorInput;
    }

    private void OnDisable()
    {
        inputController.Disable();
        inputController.Player.Take.performed -= HandleDoorInput;
    }

    private void HandleDoorInput(InputAction.CallbackContext context)
    {
        if (isPlayerNearby)
        {
            if (animator != null)
            {
                bool isOpen = animator.GetBool("OpenAnimR");
                animator.SetBool("OpenAnimR", !isOpen);
            }
            else
            {
                Debug.LogError("HandleDoorInput: Animator �� null �ł��BRefrigerator2 �� Animator �����邩�m�F���Ă��������B", this);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
