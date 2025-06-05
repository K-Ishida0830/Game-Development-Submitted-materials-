using UnityEngine;
using UnityEngine.AI;

public class reltukiyo : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 10f;  // ���m�͈�
    public float sightAngle = 60f;      // ���E�p�x�i�L���܂����j
    public LayerMask obstacleLayer;     // ��Q�����C���[
    public float loseSightDelay = 2f;   // ����������̑ҋ@����

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
            lostSightTimer = 0f;  // �v���C���[�����m�����̂Ń^�C�}�[�����Z�b�g

            if (!isChasing)
            {
                SetChaseMode();  // �v���C���[�����m������ǐՃ��[�h�ɐ؂�ւ�
            }
        }
        else
        {
            if (isChasing)
            {
                lostSightTimer += Time.deltaTime;  // �v���C���[���������Ă���ԁA�^�C�}�[��i�߂�

                if (lostSightTimer >= loseSightDelay)
                {
                    SetHaikaiMode();  // �������Ă����莞�Ԍo�߂�����p�j���[�h�ɐ؂�ւ�
                }
            }
        }
    }

    // �v���C���[�����E�Ō��m���郁�\�b�h
    private bool CanSeePlayer()
    {
        if (player == null) return false;

        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, player.position);

        // �v���C���[�����m�͈͓��ɂ��邩
        if (distance > detectionRange) return false;

        // ���E�p�x����
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        if (angle > sightAngle / 2f) return false;

        // ���E���ɏ�Q�����Ȃ����`�F�b�N
        RaycastHit hit;
        if (Physics.Raycast(transform.position, directionToPlayer, out hit, detectionRange, obstacleLayer))
        {
            if (hit.collider != null && hit.collider.gameObject != player.gameObject)
            {
                return false;  // ��Q�����v���C���[�̊Ԃɂ���
            }
        }

        return true;
    }

    // �p�j���[�h�ɕύX
    private void SetHaikaiMode()
    {
        isChasing = false;

        if (haikaiScript != null)
            haikaiScript.enabled = true;

        if (onimanagerScript != null)
            onimanagerScript.enabled = false;

        Debug.Log("���[�h: �p�j");
    }

    // �ǐՃ��[�h�ɕύX
    private void SetChaseMode()
    {
        isChasing = true;

        if (haikaiScript != null)
            haikaiScript.enabled = false;

        if (onimanagerScript != null)
            onimanagerScript.enabled = true;

        Debug.Log("���[�h: �ǐ�");
    }
}
