using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Transform itemsParent;

    Inventory inventory;

    void Start()
    {
        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;

        // ���o���~�檺Compoments
    }

    private void UpdateUI() //��G�v�@��s�Ҧ�slots�A�̾�items���ƶq�A�Ϩ����/�R��slots������
    {


    }    
}
