using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraslationLevel : MonoBehaviour
{
    [SerializeField] private float _velocity;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(transform.position.x, transform.position.y, (transform.position.z + (Time.deltaTime * _velocity) * -1));
        transform.position = direction;
    }

}
