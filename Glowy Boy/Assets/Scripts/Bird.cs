using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float birdFlySpeed = 5f;
    [SerializeField] float birdYSpeed = 3f;
    [SerializeField] AudioClip birdFly;

    Rigidbody2D myRigidBody;
    Animator myAnimator;

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        myAnimator.SetBool("IsFlying", true);
        Fly();
    }

    private void Fly()
    {
        AudioSource.PlayClipAtPoint(birdFly, Camera.main.transform.position);
        myRigidBody.velocity = new Vector2(transform.position.x * birdFlySpeed, transform.position.y * birdYSpeed);
    }
}
