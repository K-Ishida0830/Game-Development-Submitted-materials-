using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwichInteraction_Auto : MonoBehaviour
{
    public Light targetLight;  // Inspector�őΏۂ̃��C�g��ݒ�
    private bool isPlayerInside = false;

    void Start()
    {
        if (targetLight != null)
        {
            targetLight.enabled = false;  // ������Ԃŏ���
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            if (targetLight != null)
            {
                CancelInvoke("TurnOffLight"); // �I�t�̗\�񂪂���΃L�����Z��
                targetLight.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            Invoke("TurnOffLight", 2f); // 2�b��ɃI�t�ɂ���\��
        }
    }

    private void TurnOffLight()
    {
        if (!isPlayerInside && targetLight != null)
        {
            targetLight.enabled = false;
        }
    }
}
