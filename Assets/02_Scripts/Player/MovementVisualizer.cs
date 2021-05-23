using UnityEngine;
using UnityEngine.VFX;


[RequireComponent(typeof(MovementController))]
public class MovementVisualizer : MonoBehaviour
{
    [SerializeField] private VisualEffect visualizationObject = null;
    [SerializeField] private string propertyName = "ActualCharge";
    MovementController controller = null;
    void Awake()
    {
        controller = GetComponent<MovementController>();
    }

    void Update()
    {
        // float angle = Mathf.Rad2Deg * -Mathf.Atan2( controller.Direction.x, controller.Direction.y);
        // visualizationObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        // Vector3 newScaling = visualizationObject.transform.localScale;
        // newScaling.z = controller.ChargeAmount * visualizationLength;

        visualizationObject.SetFloat(propertyName, controller.ChargeAmount);

        // visualizationObject.transform.localScale = newScaling;
    }
}
