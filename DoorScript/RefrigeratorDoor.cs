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

        // 親オブジェクト（Refrigerator2）から Animator を取得
        Transform parent = transform.parent;  // `Refrigerator2`
        if (parent != null)
        {
            animator = parent.GetComponent<Animator>();
        }

        // Animator が見つからない場合はエラーメッセージを出力
        if (animator == null)
        {
            Debug.LogError("Animator が Refrigerator2 に見つかりません！", this);
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
                Debug.LogError("HandleDoorInput: Animator が null です。Refrigerator2 に Animator があるか確認してください。", this);
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
