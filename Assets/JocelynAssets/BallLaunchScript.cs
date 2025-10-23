using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLaunchScript : MonoBehaviour
{
    public float launchForce = 10f;
    private Vector2 startPoint;
    private Vector2 endPoint;
    private Vector2 direction;
    private bool isDragging = false;
    private Rigidbody2D rb;
    [SerializeField] GameObject myArrow;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myArrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse input
        if (Input.GetMouseButtonDown(0))
        {
            myArrow.SetActive(true);
            startPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
        else if (Input.GetMouseButtonUp(0) && isDragging)
        {
            myArrow.SetActive(false);
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

            //arrow signalling
            myArrow.transform.localScale = new Vector3(direction.magnitude / 4, 1, 1);
            float myAngle = Mathf.Atan2((startPoint.y - endPoint.y),(startPoint.x - endPoint.x ));
            myAngle *= Mathf.Rad2Deg;
            myArrow.transform.eulerAngles = new Vector3(0, 0, myAngle);
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
}
