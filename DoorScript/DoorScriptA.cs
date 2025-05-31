using UnityEngine;
using UnityEngine.InputSystem;

public class DoorScriptA : MonoBehaviour
{
    private Animator animator;  // Animatorを参照
    private @InputController inputController;  // InputControllerを参照
    private bool isPlayerNearby = false;  // プレイヤーが近くにいるかを追跡するフラグ

    private void Awake()
    {
        inputController = new @InputController();  // InputControllerをインスタンス化
        animator = GetComponentInParent<Animator>();  // 親オブジェクトからAnimatorを取得
    }

    private void OnEnable()
    {
        inputController.Enable();  // 入力を有効化
        inputController.Player.Take.performed += HandleDoorInput;  // Takeアクションが実行されたときの処理を追加
    }

    private void OnDisable()
    {
        inputController.Disable();  // 入力を無効化
        inputController.Player.Take.performed -= HandleDoorInput;  // イベントハンドラを解除
    }

    private void HandleDoorInput(InputAction.CallbackContext context)
    {
        if (isPlayerNearby)  // プレイヤーが近くにいる場合のみ開ける
        {
            bool isOpen = animator.GetBool("Open02");  // 現在の状態を取得
            animator.SetBool("Open02", !isOpen);  // アニメーションを反転させる
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // プレイヤーがSearchAreaに入ったら
        {
            isPlayerNearby = true;  // フラグを立てる
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // プレイヤーがSearchAreaから離れたら
        {
            isPlayerNearby = false;  // フラグを解除
        }
    }
}
