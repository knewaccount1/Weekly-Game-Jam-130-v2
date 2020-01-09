using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    RaycastHit2D hit;
    public float distance = 10f;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("punch");
            hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);
            if (hit.collider != null && hit.collider.tag == "Destructable")
            {
                hit.collider.gameObject.GetComponent<Destructable>().DestroyIt();
                
            }

            if (hit.collider.tag == "Enemy" && hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<Enemies>().DestroyIt();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}

