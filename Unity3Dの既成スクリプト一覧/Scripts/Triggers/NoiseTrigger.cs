using UnityEngine;
using UnityEngine.Playables;

public class NoiseTrigger : MonoBehaviour
{
    [Header("接触対象のオブジェクト")]
    public GameObject targetObject;  // インスペクターで指定

    [Header("再生するTimeline")]
    public PlayableDirector timeline;

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.gameObject == targetObject)
        {
            if (timeline != null)
            {
                timeline.Play();
                hasTriggered = true;
            }
            else
            {
                Debug.LogWarning("Timeline が指定されていません！");
            }
        }
    }
}
