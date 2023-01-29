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

    public GameObject craftMenu;

    void Start()
    {

        craftMenu.SetActive(false);

    }

    public void MenuOpen()
    {
        craftMenu.SetActive(true);

        UIManager.Instance.Pause();
    }
}
