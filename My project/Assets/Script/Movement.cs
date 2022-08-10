using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    

    public float distance;
   
    public Camera camera;

    private RaycastHit hit;

    private NavMeshAgent agent;

    private string groundTag = "Ground";


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))

        {
            
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Default"))
                {
                    distance = Vector3.Distance(transform.position, hit.point);
                    Debug.Log("distance" + distance);
                    agent.SetDestination(hit.point);
                }
            }
        }
    }
}
