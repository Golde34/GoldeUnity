using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class KingBeheviour : MonoBehaviour
{
    [SerializeField] Transform target;

    List<Vector2> points;

    private NavMeshAgent agent;
    LineRenderer lineRenderer;
    List<Vector3> point;
    Vector2 localScale;
    Animator animator;
    Vector2 placeToGo;
    public GameOverScript gameOverScript;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        lineRenderer = GetComponent<LineRenderer>();

        agent.updateUpAxis = false;
        agent.updateRotation = false;
        animator = gameObject.GetComponent<Animator>();
        agent.speed = 5;

        points = new List<Vector2>();
        points.Add(new Vector2(-1.33f, 9.36f));
        points.Add(new Vector2(14.15f, 10.05f));
        points.Add(new Vector2(2.69f, -5.05f));
        points.Add(new Vector2(-3.72f, -4.62f));
        points.Add(new Vector2(15.83f, -6.3f));
        points.Add(new Vector2(13.24f, -30.31f));
        points.Add(new Vector2(42.89f, -1.35f));
        points.Add(new Vector2(49.84f, -8.61f));
        points.Add(new Vector2(44.36f, -25.29f));
        points.Add(new Vector2(54.86f, -25.37f));

        int index = Random.RandomRange(0, points.Count - 1);

        placeToGo = points[index];
    }

    // Update is called once per frame
    public void Update()
    {
        if (calculateDistance() < 8)
        {
            chasePig();
        }
        else
        {
            Debug.Log("Out of sight");
            walkRandomly();
        }

        float difX = Mathf.Abs(target.transform.position.x - agent.transform.position.x);
        float difY = Mathf.Abs(target.transform.position.y - agent.transform.position.y);

        if (difX < 0.2 && difY < 0.2)
        {
            gameOverScript.Setup();
        }
    }

    private float calculateDistance()
    {
        Vector2 difference = new Vector2(agent.transform.position.x - target.position.x, agent.transform.position.y - target.position.y);
        return Mathf.Sqrt(Mathf.Pow(difference.x, 2f) + Mathf.Pow(difference.y, 2f));
    }

    private void walkRandomly()
    {
        float difX = Mathf.Abs(agent.transform.position.x - placeToGo.x);
        float difY = Mathf.Abs(agent.transform.position.y - placeToGo.y);
        agent.SetDestination(placeToGo);
        if (placeToGo.x < gameObject.transform.position.x)
        {
            localScale = gameObject.transform.localScale;
            if (localScale.x > 0)
            {
                localScale.x *= -1;
                this.gameObject.transform.localScale = localScale;
            }
        }
        else if (placeToGo.x > gameObject.transform.position.x)
        {
            localScale = gameObject.transform.localScale;
            if (localScale.x < 0)
            {
                localScale.x *= -1;
                this.gameObject.transform.localScale = localScale;
            }
        }

        animator.SetBool("isRun", true);

        if (difX < 0.5 && difY < 0.5)
        {
            int index = Random.RandomRange(0, points.Count - 1);

            placeToGo = points[index];

            Debug.Log(placeToGo);
        }
    }

    private void chasePig()
    {
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
