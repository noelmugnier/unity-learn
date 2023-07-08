using UnityEngine;
using UnityEngine.UI;

public class FoodProvider : MonoBehaviour
{
    [SerializeField] private float _requiredFood = 1;
    [SerializeField] private Slider _slider;
    private float _remainingFood;

    private void Awake()
    {
        _remainingFood = _requiredFood;
        _slider.maxValue = 1;
        _slider.value = 1;

        if (transform.forward.x != 0f)
        {
            var canvas = GetComponentInChildren<Canvas>();
            canvas.transform.Rotate(canvas.transform.right, -90);
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        var playerController = other.GetComponent<PlayerController>();
        if (playerController != null)
        {
            GameManager.Instance.DecreaseLives();
            Destroy(gameObject);
            return;
        }
        
        var projectile = other.GetComponent<Projectile>();
        if (projectile == null)
            return;
        
        if (_remainingFood < 1) 
            return;
        
        _remainingFood--;
        _slider.value = _remainingFood / _requiredFood;
        if (_remainingFood > 0) 
            return;
        
        GameManager.Instance.IncreaseScore();
        Destroy(gameObject);
    }
}