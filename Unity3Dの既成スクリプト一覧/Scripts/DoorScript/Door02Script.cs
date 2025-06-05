using UnityEngine;
using UnityEngine.InputSystem;

public class Door02Script : MonoBehaviour
{
    private Animator animator;  // Animatorを参照
    private @InputController inputController;  // InputControllerを参照
    private bool isPlayerNearby = false;  // プレイヤーが近くにいるかを追跡するフラグ

    public RuntimeAnimatorController doorAnimatorController; // 追加: アニメーターコントローラーの参照

    private void Awake()
    {
        inputController = new @InputController();  // InputControllerをインスタンス化
        animator = GetComponentInParent<Animator>();  // 親オブジェクトからAnimatorを取得
        animator.runtimeAnimatorController = doorAnimatorController;  // 親オブジェクトにRoomDoor02アニメーターコントローラーを設定
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
            bool isOpen = animator.GetBool("OpenAnim02");  // "OpenAnim02" というパラメーターを取得
            animator.SetBool("OpenAnim02", !isOpen);  // OpenAnim02パラメーターを反転させてドアを開ける/閉じる
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
