using UnityEngine;
public class GameManager : MonoBehaviour
{
    public Player player;
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    private void Start()
    {
        player = GameObject.FindAnyObjectByType<Player>();
        if (player == null)
        {
            Debug.LogError("Player no encontrado en la escena.");
        }
        else
        {
            Debug.Log("Player encontrado: " + player);
        }
    }
}
