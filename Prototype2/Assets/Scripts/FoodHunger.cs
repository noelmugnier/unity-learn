using UnityEngine;
using UnityEngine.UI;

public class FoodHunger : MonoBehaviour
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

    public void Feed()
    {
        if (_remainingFood < 1) 
            return;
        
        _remainingFood--;
        _slider.value = _remainingFood / _requiredFood;
        if (_remainingFood <= 0)
        {
            GameManager.Instance.IncreaseScore();
            Destroy(gameObject);
        }
    }
}
