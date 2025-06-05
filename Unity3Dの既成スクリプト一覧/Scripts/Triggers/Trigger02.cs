using UnityEngine;
using UnityEngine.Playables;
using StarterAssets;

public class Trigger02 : MonoBehaviour
{
    public PlayableDirector timeline;
    public PlayableDirector activationTimeline;
    public GameObject subtitleObject;
    public GameObject player;

    public GameObject disableObject1; // 追加：無効化対象1
    public GameObject disableObject2; // 追加：無効化対象2
    public GameObject enableObject; // 追加：有効化対象1（1個だけ）

    private bool triggerEnabled = false;  // 最初は無効化状態
    private bool subtitleWasActive = true;
    private bool isPlayerFrozen = false;
    private ThirdPersonController thirdPersonController;

    private void Start()
    {
        triggerEnabled = false;  // 最初は無効化

        if (activationTimeline != null)
        {
            activationTimeline.stopped += OnActivationTimelineFinished;
        }

        if (subtitleObject != null)
        {
            subtitleWasActive = subtitleObject.activeSelf;
        }

        if (player != null)
        {
            thirdPersonController = player.GetComponent<ThirdPersonController>();
        }
    }

    private void Update()
    {
        // subtitleObjectが非表示になったときにトリガーを有効化
        if (subtitleObject != null)
        {
            if (subtitleWasActive && !subtitleObject.activeSelf)
            {
                triggerEnabled = true;  // 字幕非表示 → トリガー有効化
                Debug.Log("字幕が非表示になった → トリガー有効化");
            }

            subtitleWasActive = subtitleObject.activeSelf;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーが触れた時に有効化される
        if (triggerEnabled && other.CompareTag("Player"))
        {
            if (timeline != null)
            {
                timeline.Play();
            }
            else
            {
                Debug.LogWarning("Timelineが設定されていません！");
            }

            FreezePlayer();

            // 指定されたオブジェクトを無効化（非表示に）
            if (disableObject1 != null) disableObject1.SetActive(false);
            if (disableObject2 != null) disableObject2.SetActive(false);

            // 1つの指定オブジェクトを有効化（表示）
            if (enableObject != null) enableObject.SetActive(true);

            triggerEnabled = false;  // トリガーは一度きりなので無効化
        }
    }

    private void OnActivationTimelineFinished(PlayableDirector pd)
    {
        if (pd == activationTimeline)
        {
            Debug.Log("アニメーション終了 → トリガー有効化");
            UnfreezePlayer();
        }
    }

    private void FreezePlayer()
    {
        if (thirdPersonController != null)
        {
            thirdPersonController.enabled = false;
            isPlayerFrozen = true;
        }
    }

    private void UnfreezePlayer()
    {
        if (thirdPersonController != null)
        {
            thirdPersonController.enabled = true;
            isPlayerFrozen = false;
        }
    }

    private void OnDestroy()
    {
        if (activationTimeline != null)
        {
            activationTimeline.stopped -= OnActivationTimelineFinished;
        }
    }
}
