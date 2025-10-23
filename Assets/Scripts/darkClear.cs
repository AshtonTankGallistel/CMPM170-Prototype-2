using UnityEngine;

public class darkClear : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "darkness")
        {
            Destroy(collision.gameObject);
        }
    }
}
