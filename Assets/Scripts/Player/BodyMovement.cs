using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    [SerializeField] float maxSpeed = 5.0f;
    [SerializeField] float maxAcceleration = 1.0f;
    [SerializeField] Animator animator;
    [HideInInspector] public Vector2 viewDirection;
    Vector2 currentDirection;
    public GameObject diresction;

    IInput input;
    Rigidbody2D body;
    Vector2 targetVelocity;

    void Awake()
    {
        input = GetComponent<IInput>();
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        targetVelocity = new Vector2(input.Horizontal, input.Vertical);
        targetVelocity = Vector2.ClampMagnitude(targetVelocity, 1.0f);

        targetVelocity *= maxSpeed;

        diresction.transform.position = new Vector3(this.transform.position.x + viewDirection.x, this.transform.position.y + viewDirection.y, diresction.transform.position.z);
    }

    void FixedUpdate()
    {
        Vector2 velocity = body.velocity;

        float maxSpeedChange = maxAcceleration * Time.deltaTime;

        velocity.x = Mathf.MoveTowards(body.velocity.x, targetVelocity.x, maxSpeedChange);
        velocity.y = Mathf.MoveTowards(body.velocity.y, targetVelocity.y, maxSpeedChange);

        body.velocity = velocity;

        animator.SetFloat("Horizontal", velocity.x);
        animator.SetFloat("Vertical", velocity.y);
        animator.SetFloat("Velocity", velocity.magnitude);
        currentDirection = new Vector2(input.Horizontal, input.Vertical).normalized;
        if (input.Horizontal !=0 || input.Vertical != 0)
        {
            viewDirection = currentDirection;
        }
    }

    public void ChangeSpeed(float value)
    {
        maxSpeed = value;
    }


}