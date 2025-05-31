using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light lightSource; // Drag your light source here
    public bool isOn = true; // If you want the light to start as ON

    private void Start()
    {
        if (lightSource)
        {
            lightSource.enabled = isOn;
        }
    }

    public void ToggleLight()
    {
        if (lightSource)
        {
            isOn = !isOn;
            lightSource.enabled = isOn;
        }
    }
}