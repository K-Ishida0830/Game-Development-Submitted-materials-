using UnityEngine;
using UnityEngine.AI;

public class reltukiyo : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;  // 感知範囲
    public float sightAngle = 60f;      // 視界角度（広げました）
    public LayerMask obstacleLayer;     // 障害物レイヤー
    public float loseSightDelay = 2f;   // 見失った後の待機時間

    private haikai haikaiScript;
    private Onimanager onimanagerScript;

    private float lostSightTimer = 0f;
    private bool isChasing = false;

    private void Start()
    {
        haikaiScript = GetComponent<haikai>();
        onimanagerScript = GetComponent<Onimanager>();

        SetHaikaiMode();
    }

    private void Update()
    {
        if (CanSeePlayer())
        {
            lostSightTimer = 0f;  // プレイヤーを感知したのでタイマーをリセット

            if (!isChasing)
            {
                SetChaseMode();  // プレイヤーを感知したら追跡モードに切り替え
            }
        }
        else
        {
            if (isChasing)
            {
                lostSightTimer += Time.deltaTime;  // プレイヤーを見失っている間、タイマーを進める

                if (lostSightTimer >= loseSightDelay)
                {
                    SetHaikaiMode();  // 見失ってから一定時間経過したら徘徊モードに切り替え
                }
            }
        }
    }

    // プレイヤーを視界で検知するメソッド
    private bool CanSeePlayer()
    {
        if (player == null) return false;

        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        // プレイヤーが感知範囲内にいるか
        if (distance > detectionRange) return false;

        // 視界角度内か
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        if (angle > sightAngle / 2f) return false;

        // 視界内に障害物がないかチェック
        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange, obstacleLayer))
        {
            if (hit.collider != null && hit.collider.gameObject != player.gameObject)
            {
                return false;  // 障害物がプレイヤーの間にある
            }
        }

        return true;
    }

    // 徘徊モードに変更
    private void SetHaikaiMode()
    {
        isChasing = false;

        if (haikaiScript != null)
            haikaiScript.enabled = true;

        if (onimanagerScript != null)
            onimanagerScript.enabled = false;

        Debug.Log("モード: 徘徊");
    }

    // 追跡モードに変更
    private void SetChaseMode()
    {
        isChasing = true;

        if (haikaiScript != null)
            haikaiScript.enabled = false;

        if (onimanagerScript != null)
            onimanagerScript.enabled = true;

        Debug.Log("モード: 追跡");
    }
}
