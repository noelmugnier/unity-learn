using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.CollideEnemy();
            return;
        }

        var foodProvider = gameObject.GetComponent<FoodHunger>();
        foodProvider.Feed();
        
        Destroy(other.gameObject);
    }
}
