using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LivesController : MonoBehaviour
{
    [Header("Sprites")]
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    [SerializeField] private Image[] hearts;

    private int currentHealth;

    private void Start()
    {
        currentHealth = hearts.Length;
    }

    public int GetHealth()
    {
        return currentHealth;
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        
        if(currentHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }

        hearts[currentHealth].sprite = emptyHeart;
    }
}
