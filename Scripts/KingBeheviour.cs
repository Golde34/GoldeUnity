using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class KingBeheviour : MonoBehaviour
{
    [SerializeField] Transform target;

    List<Vector2> points;
    public Location[] locationPoints;
    private NavMeshAgent agent;
    LineRenderer lineRenderer;
    List<Vector3> point;
    Vector2 localScale;
    Animator animator;
    Vector2 placeToGo;
    public GameOverScript gameOverScript;
    Boolean isOver = false;
    public AudioSource chaseMusic;

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
        var jsonTextFile = Resources.Load<TextAsset>("Text/kingCheckLocation");
        Debug.Log(jsonTextFile.text);
        locationPoints = JsonHelper.FromJson<Location>(jsonTextFile.text);
        foreach(var point in locationPoints)
        {
            points.Add(new Vector2(point.x, point.y));
        }

        int index = Random.Range(0, points.Count - 1);

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
            walkRandomly();
        }


        float difX = Mathf.Abs(target.transform.position.x - agent.transform.position.x);
        float difY = Mathf.Abs(target.transform.position.y - agent.transform.position.y);

        if (difX < 2 && difY < 2)
        {
            animator.SetBool("canAttack", true);
        }
        else
        {
            animator.SetBool("canAttack", false);
        }

        if (difX < 0.7 && difY < 0.7)
        {
            gameOverScript.Setup();
            isOver = true;
        }
        if (Input.GetKey(KeyCode.Space) && isOver == true)
        {
            gameOverScript.RestartButton();
            isOver = false;
        }
    }

    private float calculateDistance()
    {
        Vector2 difference = new Vector2(agent.transform.position.x - target.position.x, agent.transform.position.y - target.position.y);
        return Mathf.Sqrt(Mathf.Pow(difference.x, 2f) + Mathf.Pow(difference.y, 2f));
    }

    private void walkRandomly()
    {
        chaseMusic.Play(0);
        float difX = Mathf.Abs(agent.transform.position.x - placeToGo.x);
        float difY = Mathf.Abs(agent.transform.position.y - placeToGo.y);
        agent.SetDestination(placeToGo);
        //Debug.Log("place to go: " + placeToGo);
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

        if (difX < 0.5 && difY < 0.5)
        {
            int index = Random.Range(0, points.Count - 1);

            placeToGo = points[index];
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
        //DrawPath(agent.path);
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
