using UnityEngine;
using System.Collections;
using StarterAssets;

public class Trigger01 : MonoBehaviour
{
    public GameObject ghostWalking;
    public GameObject subtitle4;
    public Camera mainCamera;
    public Camera eventCamera;
    public GameObject player; // プレイヤーオブジェクト

    public GameObject objectToDisable; // 触れたら無効にするオブジェクト
    public GameObject objectToEnable;  // 触れたら有効にするオブジェクト

    private Animator ghostAnimator;
    private bool isWaiting = false;
    private bool hasTriggered = false;
    private CharacterController playerController;
    private Rigidbody playerRigidbody;
    private ThirdPersonController thirdPersonController; // ThirdPersonController参照用

    private void Awake()
    {
        if (subtitle4 != null)
            subtitle4.SetActive(false);

        if (ghostWalking != null)
            ghostWalking.SetActive(false);

        if (eventCamera != null)
            eventCamera.enabled = false;

        // プレイヤーのコンポーネントを取得
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

            // カメラ切り替え
            if (mainCamera != null && eventCamera != null)
            {
                mainCamera.enabled = false;
                eventCamera.enabled = true;
            }

            FreezePlayer();

            // 指定オブジェクトの有効/無効切り替え
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

        // カメラ戻し & プレイヤー動作復帰
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
