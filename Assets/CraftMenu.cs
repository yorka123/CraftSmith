using UnityEngine;

public class CraftMenu : MonoBehaviour
{
    #region Singleton
    public static CraftMenu instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject Menu;
    public GameObject inventory;

    void Start()
    {
        Menu.SetActive(false);
        inventory.SetActive(false);
    }

    public void MenuOpen()
    {
        Menu.SetActive(true);
        inventory.SetActive(true);

        UIManager.Instance.Pause();
    }
}
