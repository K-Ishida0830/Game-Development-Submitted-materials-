using UnityEngine;
using StarterAssets;
using System.Collections;

public class Trigger03 : MonoBehaviour
{
    public GameObject subtitleObject;     // 表示を監視する既存字幕
    public GameObject player;             // プレイヤー
    public GameObject objectToShow;       // 表示させるキャラクターなど
    public GameObject subtitleToShow;     // 新たに表示する字幕
    public GameObject spawnObject;        // 触れたときに出現させるオブジェクト
    public Animator doorAnimator;         // ドアのAnimator

    private bool triggerEnabled = false;
    private bool subtitleWasActive = true;

    private void Start()
    {
        triggerEnabled = false;

        if (subtitleObject != null)
            subtitleWasActive = subtitleObject.activeSelf;
    }

    private void Update()
    {
        if (subtitleObject != null)
        {
            if (subtitleWasActive && !subtitleObject.activeSelf)
            {
                triggerEnabled = true;
                Debug.Log("字幕が非表示 → トリガー有効化");
            }

            subtitleWasActive = subtitleObject.activeSelf;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerEnabled && other.CompareTag("Player"))
        {
            Debug.Log("Trigger03 発動");

            // ドアアニメーション再生
            if (doorAnimator != null)
            {
                doorAnimator.SetBool("Open", true);
                Debug.Log("ドア開アニメーション再生");
            }

            // キャラクター出現
            if (objectToShow != null)
            {
                objectToShow.SetActive(true);
                Debug.Log("キャラ出現");
            }

            // 出現用のオブジェクトを表示
            if (spawnObject != null)
            {
                spawnObject.SetActive(true);
                Debug.Log("出現オブジェクト表示");
            }

            // 字幕表示 → 3秒後に非表示
            if (subtitleToShow != null)
            {
                subtitleToShow.SetActive(true);
                StartCoroutine(HideSubtitleAfterDelay(3f));
                Debug.Log("字幕表示（3秒後に非表示予定）");
            }

            triggerEnabled = false; // 一度きり
        }
    }

    private IEnumerator HideSubtitleAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (subtitleToShow != null)
        {
            subtitleToShow.SetActive(false);
            Debug.Log("字幕を非表示にしました");
        }
    }
}

