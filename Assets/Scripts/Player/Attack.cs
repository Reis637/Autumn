using NUnit.Framework;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float speed = 5f;
    public float MaxTime = 2f;
    private float timer;
    void Start()
    {
        timer = MaxTime;
    }

    void Update()
    {
        transform.position = transform.position + Vector3.left * speed * Time.deltaTime;

        timer = timer - Time.deltaTime;

        if (timer < 0)
        {
            Destroy(gameObject);
        }

    }
}
