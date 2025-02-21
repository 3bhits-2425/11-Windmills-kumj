using UnityEngine;
using UnityEngine.UI;

public class WindmillDynamicSpeed : MonoBehaviour
{
    [SerializeField] private Light lampLight;
    [SerializeField] private float maxLightIntensity = 1f;
    [SerializeField] private Slider speedSlider;
    public float maxRotationSpeed = 255f;
    [SerializeField] private float acceleration = 50f;
    [SerializeField] private float deceleration = 30f;
    private float currentSpeed = 0f;
    private bool isLocked = false;

    [SerializeField] private Button lockButton;
    [SerializeField] private GameObject colorCube;

    private static Color totalColor = Color.black; // Speichert die gemischte Farbe
    private static int lockedWindmills = 0; // Anzahl der gesperrten Windräder

    private void Start()
    {
        if (lockButton != null)
        {
            lockButton.onClick.AddListener(LockWindmillSpeed);
        }
    }

    private void Update()
    {
        if (!isLocked)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                currentSpeed += acceleration * Time.deltaTime;
            }
            else
            {
                currentSpeed -= deceleration * Time.deltaTime;
            }

            currentSpeed = Mathf.Clamp(currentSpeed, 0f, maxRotationSpeed);

            if (speedSlider != null)
            {
                speedSlider.value = Mathf.Round(currentSpeed);
            }
        }

        transform.Rotate(Vector3.forward * currentSpeed * Time.deltaTime);

        if (lampLight != null)
        {
            lampLight.intensity = Mathf.Lerp(0f, maxLightIntensity, currentSpeed / maxRotationSpeed);
        }
    }

    public void LockWindmillSpeed()
    {
        if (isLocked) return; // Verhindert mehrfaches Sperren

        isLocked = true;
        if (speedSlider != null)
        {
            speedSlider.interactable = false;
        }

        UpdateColorCube();

        Debug.Log($"Windmühle {gameObject.name} gesperrt. Geschwindigkeit eingefroren bei {currentSpeed}");
    }

    private void UpdateColorCube()
    {
        if (colorCube != null && lampLight != null)
        {
            Color windmillColor = lampLight.color;
            Renderer cubeRenderer = colorCube.GetComponent<Renderer>();

            if (cubeRenderer != null)
            {
                // Neue Farbe zur Gesamtfarbe hinzufügen
                totalColor += windmillColor;
                lockedWindmills++;

                // Durchschnitt berechnen
                cubeRenderer.material.color = totalColor / lockedWindmills;
            }
        }
    }
}
