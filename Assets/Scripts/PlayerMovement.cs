using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10;
    public float jumpForce;
    public float horizontalInput;

    public Rigidbody2D rb;
    public bool isOnGround;

    public bool hasPower;
    public GameObject indicator;
    public float cooldownTime = 30;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isOnGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }


        indicator.SetActive(hasPower);
        if (hasPower)
        {
            StartCoroutine(PowerCooldown(cooldownTime));
            isOnGround = true;
        }
    }

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(Vector2.right * moveSpeed * horizontalInput);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Power"))
        {
            hasPower = true;
            Destroy(collision.gameObject);
        }
    }

    IEnumerator PowerCooldown(float seconds)
    { 
        yield return new WaitForSeconds(seconds);
        hasPower = false;
    }
}
