using UnityEngine;
using UnityEngine.UI;
public class ManagerUI : MonoBehaviour
{
    public static ManagerUI instance;
    public Text gameOverText;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    private void Start()
    {
        HiddenText();
        DelegatesManager.instance.AddAction(KeysDelegatesEnumEvents.PlayerDeath,ShowText);
    }
    private void ShowText()
    {
        gameOverText.gameObject.SetActive(true);
        DelegatesManager.instance.RemoveAction(KeysDelegatesEnumEvents.PlayerDeath, ShowText);
    }
    private void HiddenText()
    {
        gameOverText.gameObject.SetActive(false);
    }
}
