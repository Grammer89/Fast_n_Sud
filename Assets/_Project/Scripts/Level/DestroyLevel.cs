
using UnityEngine;

public class DestroyLevel : MonoBehaviour
{
    [SerializeField] private GameObject _level;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Utility.PLAYERTAG))
        {

            Destroy(_level, 1f);
        }
    }
}
