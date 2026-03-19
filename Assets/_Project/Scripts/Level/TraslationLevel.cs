using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraslationLevel : MonoBehaviour
{
    [SerializeField] private float _velocity;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3((transform.position.x + (Time.deltaTime * _velocity) ), transform.position.y, transform.position.z );
        transform.position = newPosition ;
    }

}
