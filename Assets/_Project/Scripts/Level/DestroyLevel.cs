
using UnityEngine;

public class DestroyLevel : MonoBehaviour
{
    //private void OnEnable()
    //{
    //    LevelManager.Instance.LevelCompleted = false;
    //}
    //private void OnDisable()
    //{
    //    LevelManager.Instance.LevelCompleted = true;
    //}
   

    [SerializeField] private GameObject _level;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Utility.PLAYERTAG))
        {
           
            Destroy(_level, 1f);
        }
    }
}
