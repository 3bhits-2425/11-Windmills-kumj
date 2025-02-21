using UnityEngine;

public class SpeedManager : MonoBehaviour
{
    [SerializeField] private WindmillDynamicSpeed[] windmills;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var windmill in windmills)
            {
                if (windmill != null)
                {
                    windmill.SendMessage("Update");
                }
            }
        }
    }
}
