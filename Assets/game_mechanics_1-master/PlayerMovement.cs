using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed=10f, jumpPower=10f;
    public SpriteRenderer sprite;
    public List<Vector3> GravitationalForces;

    Rigidbody2D body;
    bool isGrounded;
    float horizontal, vertical;

    private float GravityMultiplier = 1;
    public List<KeyValuePair<Vector3, float>> GravityForces;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        vertical = Input.GetAxisRaw("Vertical");

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            body.AddForce(transform.up * jumpPower * GravityMultiplier, ForceMode2D.Impulse);
        }
        foreach(var Force in GravityForces)
        {
            transform.up = Vector3.MoveTowards(transform.up, Force.Key, Force.Value * Time.deltaTime * 5f);

        }
        GravityForces.Clear();
    }

    void FixedUpdate()
    {
       // if (isGrounded)
        //{
            body.AddForce(transform.right * horizontal * moveSpeed);
        //}
        if (!isGrounded)
        {
            body.AddForce(transform.up * vertical * moveSpeed);
        }
        sprite.flipX = horizontal > 0 ? false : (horizontal < 0 ? true : sprite.flipX);
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.CompareTag("Planet"))
        {
            body.drag = 1f;

            float distance = Mathf.Abs(obj.GetComponent<GravityPoint>().planetRadius - Vector2.Distance(transform.position, obj.transform.position));
            if (distance < 1f)
            {
                isGrounded = distance < 0.5f;
            }
            GravityMultiplier = obj.GetComponent<GravityPoint>().gravityScale;
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Planet"))
        {
            body.drag = 0.2f;
            GravityMultiplier = 1;
        }
    }
}
