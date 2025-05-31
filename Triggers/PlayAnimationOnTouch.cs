using UnityEngine;

public class PlayAnimationOnTouch : MonoBehaviour
{
    [Tooltip("再生させる対象の Animator（外から指定）")]
    public Animator targetAnimator;

    [Tooltip("再生トリガーとなる bool パラメータ名")]
    public string boolParameterName; // コード内で指定せず、インスペクターから指定

    private bool hasPlayed = false;

    void OnTriggerEnter(Collider other)
    {
        if (!hasPlayed && other.CompareTag("Player"))
        {
            if (targetAnimator != null)
            {
                // インスペクターで指定されたパラメータ名を使ってbool値を変更
                targetAnimator.SetBool(boolParameterName, true);
                hasPlayed = true;
            }
            else
            {
                Debug.LogWarning("targetAnimator が設定されていません！");
            }
        }
    }
}