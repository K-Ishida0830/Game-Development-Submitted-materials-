using UnityEngine;

public class NoiseController : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform
    public Transform ghost;   // �S�[�X�g��Transform
    public CanvasGroup noiseCanvasGroup;  // �m�C�Y��CanvasGroup
    public float maxDistance = 10f;  // �m�C�Y�̍ő�e������

    private bool isNoiseActive = false;  // �m�C�Y���L�����ǂ���

    private void OnEnable()
    {
        ItemPickup.OnItemPickedUp += ActivateNoise;
    }

    private void OnDisable()
    {
        ItemPickup.OnItemPickedUp -= ActivateNoise;
    }

    private void ActivateNoise()
    {
        isNoiseActive = true;
        Debug.Log("Noise Activated!"); // �f�o�b�O�p
    }

    void Update()
    {
        if (!isNoiseActive)
        {
            noiseCanvasGroup.alpha = 0;  // �m�C�Y���\��
            return;
        }

        // �v���C���[�ƃS�[�X�g�̈ʒu���擾
        Vector3 playerPos = player.position;
        Vector3 ghostPos = ghost.position;

        // 3D��Ԃł̋������v�Z
        float distance = Vector3.Distance(playerPos, ghostPos);

        // �f�o�b�O���O
        Debug.Log($"Player Pos: {playerPos}, Ghost Pos: {ghostPos}, Distance: {distance}");

        // �����x���v�Z (������ `maxDistance` �ȏ�Ȃ� alpha = 0, �߂Â��ق� alpha = 1)
        float alpha = Mathf.Clamp01(1 - (distance / maxDistance));

        // �����x���X���[�Y�ɕύX
        noiseCanvasGroup.alpha = Mathf.Lerp(noiseCanvasGroup.alpha, alpha, Time.deltaTime * 5f);

        // �����x�̃f�o�b�O���O
        Debug.Log($"Calculated Alpha: {alpha}");
    }
}
