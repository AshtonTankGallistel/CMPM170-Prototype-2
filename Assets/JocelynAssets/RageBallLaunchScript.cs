using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageBallLaunchScript : MonoBehaviour
{
    public float launchForce = 10f;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;
    private bool isDragging = false;
    private Rigidbody2D rb;
    public float windForce = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(ApplyWind());
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (startPoint - endPoint);
            Launch(direction);
            isDragging = false;
        }

        // Draw a line to visualize the drag
        if (isDragging)
        {
            endPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (startPoint - endPoint);
            Debug.DrawLine(startPoint, endPoint, Color.red);
        }
    }

    void Launch(Vector2 direction)
    {
        // Calculate force
        float force = direction.magnitude * launchForce;
        Vector2 launchDirection = direction.normalized;

        // Apply force to the Rigidbody2D
        rb.AddForce(launchDirection * force, ForceMode2D.Impulse);
    }

    IEnumerator ApplyWind()
    {
        while (true)
        {
            rb.AddForce(Vector2.left * windForce, ForceMode2D.Impulse);
            yield return new WaitForSeconds(1f);
        }
    }
}
