using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.GetComponent<PlayerController>() != null)
        {
            GameManager.Instance.DecreaseScore();
            return;
        }
        
        GameManager.Instance.IncreaseScore();
        Destroy(other.gameObject);
    }
}
