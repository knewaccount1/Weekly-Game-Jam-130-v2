using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabFunction : MonoBehaviour
{
    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 10f;
    public Transform holdPoint;
    public float throwForce;
    public LayerMask notGrabbed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

                if(hit.collider != null && hit.collider.tag == "Grabbable")
                {
                    grabbed = true;
                }
                
            }
            else 
            {
                grabbed = false;

                if(hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1) * throwForce;
                }
            }
        }

        if (grabbed)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
