using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float moveForce = 50f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.forward;
        rb.AddForce(dir * moveForce, ForceMode.Acceleration);
    }
}
