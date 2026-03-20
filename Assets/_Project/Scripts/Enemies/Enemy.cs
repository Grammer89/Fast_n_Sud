using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _velocity;
    public float _time;

    public float TimeEnemy { get { return _time; } }
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = new Vector3(transform.position.x + (Time.deltaTime * _velocity) , transform.position.y,  transform.position.z  );
        transform.position = direction;
        _time += Time.deltaTime;

    }

    public void ResetValue()
    {
        Debug.Log("Reset Value ", gameObject);
        _time = 0;
    }
}
