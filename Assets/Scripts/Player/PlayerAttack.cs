using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject prefab;

    public float cooldown;
    public float damage;
    public float time;
    public float speed;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject gameObject = Instantiate(prefab, transform.position, Quaternion.identity);
        }
    }
}
