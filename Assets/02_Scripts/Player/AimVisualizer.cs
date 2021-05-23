using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(AttackController))]
public class AimVisualizer : MonoBehaviour
{
    [SerializeField] private VisualEffect visualizationObject = null;
    [SerializeField] private string propertyNameCharge = "ActualCharge";
    [SerializeField] private string propertyNameDirection = "Direction";
    [SerializeField] private string propertyNameAngle = "Angle";
    AttackController controller = null;
    void Awake()
    {
        controller = GetComponent<AttackController>();
    }

    void Update()
    {
        float angle = Mathf.Rad2Deg * Mathf.Atan2(controller.Direction.x, controller.Direction.z);
        visualizationObject.transform.rotation = Quaternion.Euler(new Vector3(0, angle, 0));
        
        visualizationObject.SetFloat(propertyNameCharge, controller.IsAiming ? 1 : 0);
    }
}
