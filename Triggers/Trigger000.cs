using UnityEngine;
using System.Collections;

public class Trigger000 : MonoBehaviour
{
    public GameObject subtitleObject;  // 表示する字幕オブジェクト
    private bool hasShown = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasShown && other.CompareTag("Player"))
        {
            hasShown = true;
            if (subtitleObject != null)
            {
                subtitleObject.SetActive(true);
                StartCoroutine(HideSubtitleAfterDelay());
            }
        }
    }

    private IEnumerator HideSubtitleAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        if (subtitleObject != null)
        {
            subtitleObject.SetActive(false);
        }
    }
}
