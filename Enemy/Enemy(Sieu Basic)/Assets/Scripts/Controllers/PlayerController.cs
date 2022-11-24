using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 [RequireComponent(typeof(UnityEngine.AI.NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;

    Camera cam;
    PlayerMotor motor;

     void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
            }
        }
    }
}
