using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;
    private Vector3 rightDestination;//右端
    private Vector3 leftDestination;//左端
    private float speed = 2;
    private Vector3 velocity;
    private Vector3 direction;//方向
    private bool rightFlag = true;//右に行くか
    private bool leftFlag = false;//左に行くか

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        rightDestination = new Vector3(-6, transform.position.y, transform.position.z);
        leftDestination = new Vector3(6, transform.position.y, transform.position.z);
        velocity = Vector3.zero;
        rightFlag = true;
        leftFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CounterTimer.CanStart)
        {
            velocity = Vector3.zero;
            anim.SetFloat("Speed", 2f);
            if (rightFlag)
            {
                direction = (rightDestination - transform.position).normalized;
                transform.LookAt(new Vector3(rightDestination.x, transform.position.y, transform.position.z));
            }
            else if (leftFlag)
            {
                direction = (leftDestination - transform.position).normalized;
                transform.LookAt(new Vector3(leftDestination.x, transform.position.y, transform.position.z));
            }
            velocity = direction * speed;
            controller.Move(velocity * Time.deltaTime);

            if (Vector3.Distance(transform.position, rightDestination) < 0.5f)
            {
                rightFlag = false;
                leftFlag = true;
            }
            else if (Vector3.Distance(transform.position, leftDestination) < 0.5f)
            {
                leftFlag = false;
                rightFlag = true;
            }
        }
    }
}
