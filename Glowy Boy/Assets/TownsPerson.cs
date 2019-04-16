using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownsPerson : MonoBehaviour
{
    [SerializeField] float walkSpeed;
    [SerializeField] float minWalkTime;
    [SerializeField] float maxWalkTime;

    Rigidbody2D myRigidBody;
    Animator myAnimator;
    BoxCollider2D myCollider;

    bool isWalking;

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();

        StartCoroutine(Move());
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            myRigidBody.velocity = new Vector2(walkSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-walkSpeed, 0f);
        }
    }

    IEnumerator Move()
    {
        if (isWalking)
        {
            myAnimator.SetBool("IsWalking", true);
            myRigidBody.velocity = new Vector2(transform.position.x * walkSpeed * Time.deltaTime, 0);
            yield return new WaitForSeconds(Random.Range(minWalkTime, maxWalkTime));
        }
        else
        {
            StopWalking();
        }
    }

    private void StopWalking()
    {
        isWalking = false;
    }

    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }
}
