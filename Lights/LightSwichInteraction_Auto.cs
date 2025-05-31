using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwichInteraction_Auto : MonoBehaviour
{
    public Light targetLight;  // Inspectorで対象のライトを設定
    private bool isPlayerInside = false;

    void Start()
    {
        if (targetLight != null)
        {
            targetLight.enabled = false;  // 初期状態で消灯
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            if (targetLight != null)
            {
                CancelInvoke("TurnOffLight"); // オフの予約があればキャンセル
                targetLight.enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            Invoke("TurnOffLight", 2f); // 2秒後にオフにする予約
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
