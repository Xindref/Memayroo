using UnityEngine;
using System.Collections;

public class EnemyAi : MonoBehaviour
{
    public Transform Target;
    public float moveSpeed = 3.0f;
    public float range = 5.0f;
    public float range2 = 5.0f;
    public float stop = 0;

    private Transform myTransform;
    private Transform Distance;

    void Awake()
    {
        myTransform = transform;
    }

    void Start()
    {
        Target = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float Distance = Vector3.Distance(myTransform.position, Target.position);

        if (Distance <= range && Distance >= range2)
        {
            myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
        }
    }
}