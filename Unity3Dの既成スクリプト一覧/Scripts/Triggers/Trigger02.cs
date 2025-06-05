using UnityEngine;
using UnityEngine.Playables;
using StarterAssets;

public class Trigger02 : MonoBehaviour
{
    public PlayableDirector timeline;
    public PlayableDirector activationTimeline;
    public GameObject subtitleObject;
    public GameObject player;

    public GameObject disableObject1; // �ǉ��F�������Ώ�1
    public GameObject disableObject2; // �ǉ��F�������Ώ�2
    public GameObject enableObject; // �ǉ��F�L�����Ώ�1�i1�����j

    private bool triggerEnabled = false;  // �ŏ��͖��������
    private bool subtitleWasActive = true;
    private bool isPlayerFrozen = false;
    private ThirdPersonController thirdPersonController;

    private void Start()
    {
        triggerEnabled = false;  // �ŏ��͖�����

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
        // subtitleObject����\���ɂȂ����Ƃ��Ƀg���K�[��L����
        if (subtitleObject != null)
        {
            if (subtitleWasActive && !subtitleObject.activeSelf)
            {
                triggerEnabled = true;  // ������\�� �� �g���K�[�L����
                Debug.Log("��������\���ɂȂ��� �� �g���K�[�L����");
            }

            subtitleWasActive = subtitleObject.activeSelf;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // �v���C���[���G�ꂽ���ɗL���������
        if (triggerEnabled && other.CompareTag("Player"))
        {
            if (timeline != null)
            {
                timeline.Play();
            }
            else
            {
                Debug.LogWarning("Timeline���ݒ肳��Ă��܂���I");
            }

            FreezePlayer();

            // �w�肳�ꂽ�I�u�W�F�N�g�𖳌����i��\���Ɂj
            if (disableObject1 != null) disableObject1.SetActive(false);
            if (disableObject2 != null) disableObject2.SetActive(false);

            // 1�̎w��I�u�W�F�N�g��L�����i�\���j
            if (enableObject != null) enableObject.SetActive(true);

            triggerEnabled = false;  // �g���K�[�͈�x����Ȃ̂Ŗ�����
        }
    }

    private void OnActivationTimelineFinished(PlayableDirector pd)
    {
        if (pd == activationTimeline)
        {
            Debug.Log("�A�j���[�V�����I�� �� �g���K�[�L����");
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
