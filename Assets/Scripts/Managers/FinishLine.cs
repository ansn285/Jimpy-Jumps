using UnityEngine;

public class FinishLine : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().enabled = false;
            collision.GetComponent<Animator>().SetFloat("walk", 0);
            collision.GetComponent<Rigidbody2D>().drag = 1.25f;
        }
    }

}
