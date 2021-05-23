using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AttackController))]
public class AimVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject visualizationObject = null;
    AttackController controller = null;
    void Awake()
    {
        controller = GetComponent<AttackController>();
    }

    void Update()
    {
        float angle = Mathf.Rad2Deg * -Mathf.Atan2( controller.Direction.x, controller.Direction.y);
        visualizationObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        visualizationObject.transform.localScale = controller.IsAiming? Vector3.one : Vector3.zero;
    }
}
