using UnityEngine;
using UnityEngine.Playables;

public class Trigger04 : MonoBehaviour
{
    public PlayableDirector timeline;
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            timeline?.Play();
            hasPlayed = true;
            Debug.Log("Trigger03: Timeline�Đ��i1��̂݁j");
        }
    }
}
