using UnityEngine;

public class WindmillRotationConstantSpeed : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    private bool isFrozen = false;

    private void Update()
    {
        if (!isFrozen)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    public void FreezeWindmill()
    {
        isFrozen = true;
    }
}
