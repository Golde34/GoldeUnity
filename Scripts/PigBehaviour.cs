using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigBehaviour : MonoBehaviour
{

    public bool isDetected = false;
    Rigidbody2D rigid;
    public Vector2 speed1 = new Vector2(0, 1f);
    public Vector2 speed2 = new Vector2(1f, 0);
    Vector2 localScale;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rigid = this.gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    void GoDown(float force)
    {
        gameObject.transform.Translate(-speed1 * Time.deltaTime * 2);
    }

    void GoUp(float force)
    {
        gameObject.transform.Translate(speed1 * Time.deltaTime * 2);
    }

    void GoRight(float force)
    {
        gameObject.transform.Translate(speed2 * Time.deltaTime * 2);

        localScale = transform.localScale;
        if(localScale.x > 0)
        {
            localScale.x *= -1;
            this.gameObject.transform.localScale = localScale;
        }
    }

    void GoLeft(float force)
    {
        gameObject.transform.Translate(-speed2 * Time.deltaTime * 2);
        if (localScale.x < 0)
        {
            localScale.x *= -1;
            this.gameObject.transform.localScale = localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isRun", true);
            GoLeft(0.5f);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isRun", true);
            GoRight(0.5f);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("isRun", true);
            GoUp(0.5f);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isRun", true);
            GoDown(0.5f);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isDetected = !isDetected;
        }

        if (!Input.anyKey)
        {
            animator.SetBool("isRun", false);
        }
    }
}
