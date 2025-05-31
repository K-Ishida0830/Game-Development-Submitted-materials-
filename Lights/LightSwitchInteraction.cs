using UnityEngine;

public class LightSwitchInteraction : MonoBehaviour
{
    public LightSwitch lightSwitch; // Reference to our LightSwitch script
    private bool playerInZone = false;

    private void Update()
    {
        if (playerInZone && Input.GetKeyDown(KeyCode.T)) // T key is used for interaction in this example
        {
            lightSwitch.ToggleLight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInZone = false;
        }
    }
}