using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    float horizontal;
    public float speed = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        Rigidbody2D.linearVelocity = new Vector2(horizontal * 5f, Rigidbody2D.linearVelocity.y);
    }

}


