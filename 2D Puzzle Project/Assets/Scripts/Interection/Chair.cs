using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour
{
    private Vector2 initiolPosition;
    private Rigidbody2D rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        initiolPosition = transform.position;
    }
    public void ResetState()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        transform.position = initiolPosition;
    }



    public void SetInitialPosition(Vector2 pos)
    {
        initiolPosition = pos;
    }
}
