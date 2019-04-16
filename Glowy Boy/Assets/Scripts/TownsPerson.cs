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

    // Start is called before the first frame update
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myCollider = GetComponent<BoxCollider2D>();

        StartWalking();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StopWalking()
    {
        myAnimator.SetBool("IsWalking", false);
        myRigidBody.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(Random.Range(minWalkTime, maxWalkTime));

        StartWalking();
    }

    private void StartWalking()
    {
        myAnimator.SetBool("IsWalking", true);
        if (IsFacingRight())
        {
            myRigidBody.velocity = new Vector2(walkSpeed, 0f);
        }
        else
        {
            myRigidBody.velocity = new Vector2(-walkSpeed, 0f);
        }
    }

    bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidBody.velocity.x)), 1f);
        StartCoroutine(StopWalking());
    }
}
