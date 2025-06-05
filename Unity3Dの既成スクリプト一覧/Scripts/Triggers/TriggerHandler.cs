using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public GameObject ghostWalkingObject; // GhostWalkingオブジェクトをインスペクターでセット
    private Animator ghostWalkingAnimator; // Animatorコンポーネント

    void Start()
    {
        // GhostWalkingオブジェクトのAnimatorコンポーネントを取得
        if (ghostWalkingObject != null)
        {
            ghostWalkingAnimator = ghostWalkingObject.GetComponent<Animator>();
        }
        else
        {
            Debug.LogError("GhostWalkingオブジェクトが設定されていません！");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // プレイヤーがトリガーに触れた場合
        {
            PlayStandbyAnimation(); // GhostWalking1アニメーターのStandbyアニメーションを作動させる
        }
    }

    void PlayStandbyAnimation()
    {
        if (ghostWalkingAnimator != null)
        {
            // "Standby" アニメーションを再生
            ghostWalkingAnimator.Play("Standby");
        }
    }
}
