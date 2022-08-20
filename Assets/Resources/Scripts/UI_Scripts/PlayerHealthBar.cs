using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    public Image image;

    private Health _playerHealth;

    private void OnEnable()
    {
        _playerHealth.OnChange += Fill;
    }

    private void OnDisable()
    {
        _playerHealth.OnChange -= Fill;
    }

    private void Awake()
    {
        var playerController = FindObjectOfType<PlayerController>();
        _playerHealth = playerController.GetComponent<Health>();        
    }

    private void Fill()
    {
        image.fillAmount = _playerHealth.GetPercentage();
    }
}