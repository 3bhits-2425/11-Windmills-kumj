using UnityEngine;
using UnityEngine.UI;

public class SpeedScript : MonoBehaviour
{
    public Transform rotorHub;
    public Button stopButton;
    private float rotationSpeed = 0f;
    private bool isFrozen = false;

    void Start()
    {
        if (stopButton != null)
        {
            stopButton.onClick.AddListener(FreezeSpeed);
        }
    }

    void Update()
    {
        if (!isFrozen)
        {
            rotorHub.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    public void SetRotationSpeed(float speed)
    {
        if (!isFrozen)
        {
            rotationSpeed = speed;
        }
    }

    public void FreezeSpeed()
    {
        isFrozen = true;
        Debug.Log("Windmühle gestoppt!");
    }
}
