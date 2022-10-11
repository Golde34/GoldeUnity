using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class KingBeheviour : MonoBehaviour
{
    [SerializeField] Transform target;

    private NavMeshAgent agent;
    LineRenderer lineRenderer;
    List<Vector3> point;
    Vector2 localScale;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        lineRenderer = GetComponent<LineRenderer>();

        agent.updateUpAxis = false;
        agent.updateRotation = false;
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PigBehaviour>().isDetected == true)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            if (target.position.x < gameObject.transform.position.x)
            {
                localScale = gameObject.transform.localScale;
                if (localScale.x > 0)
                {
                    localScale.x *= -1;
                    this.gameObject.transform.localScale = localScale;
                }
            }
            else if (target.position.x > gameObject.transform.position.x)
            {
                localScale = gameObject.transform.localScale;
                if (localScale.x < 0)
                {
                    localScale.x *= -1;
                    this.gameObject.transform.localScale = localScale;
                }
            }
            DrawPath(agent.path);
            animator.SetBool("isRun", true);
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("isRun", false);
        }
    }

    private void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2) return;
        int i = 1;
        while (i < path.corners.Length)
        {
            lineRenderer.positionCount = path.corners.Length;
            point = path.corners.ToList();
            for (int j = 0; j < point.Count; j++)
            {
                lineRenderer.SetPosition(j, point[j]);
            }

            i++;
        }
    }
}
