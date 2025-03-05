using UnityEngine;

public class LinealMovement : MonoBehaviour
{
    public float speed = 3f;
    public float leftLimit;
    public float rightLimit;

    private int direction = 1; // 1 = derecha, -1 = izquierda
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        transform.position += Vector3.right * direction * speed * Time.deltaTime;
        animator.SetBool("walk", true);

        if (transform.position.x >= rightLimit || transform.position.x <= leftLimit)
        {
            direction *= -1;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -transform.localScale.z);
        }
    }
}
