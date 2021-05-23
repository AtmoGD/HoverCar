using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MovementController))]
public class MovementVisualizer : MonoBehaviour
{
    [SerializeField] private GameObject visualizationObject = null;
    MovementController controller = null;
    void Awake()
    {
        controller = GetComponent<MovementController>();
    }

    void Update()
    {
        float angle = Mathf.Rad2Deg * -Mathf.Atan2( controller.Direction.x, controller.Direction.y);
        visualizationObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        visualizationObject.transform.localScale = Vector3.one * controller.ChargeAmount;
    }
}
