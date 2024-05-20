using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows.WebCam;

[RequireComponent(typeof(NavMeshAgent))]
public class Move : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private AnimationHandler anim;
    [SerializeField] private Camera camera;
    private Ray _ray;
    private RaycastHit _hit;
    private bool _isMoving;

    private void Awake()
    {
        agent ??= GetComponent<NavMeshAgent>();
        camera ??= Camera.main;
    }
    private void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            _ray = camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(_ray, out _hit, 1000f))
            {
                agent.destination = _hit.point;
                anim.SetAnimation("idle2", false);
                _isMoving = true;
            }
        }
    }
    private void FixedUpdate()
    {
       
        if (_isMoving)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                anim.SetAnimation("idle2",true);
                _isMoving = false;
            }
        }
    }
}
