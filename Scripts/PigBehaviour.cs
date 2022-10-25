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

        if (!Input.anyKey)
        {
            animator.SetBool("isRun", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.StartsWith("Box"))
        {
            StartCoroutine(BreakBox(collision));
            
        }
    }

    IEnumerator BreakBox(Collision2D collision)
    {
        animator.SetBool("canAttack", true);
        BoxScript boxScript = collision.gameObject.GetComponent<BoxScript>();

        yield return new WaitForSeconds(0.5f);

        boxScript.isDestroy = true;
        animator.SetBool("canAttack", false);

    }
}
