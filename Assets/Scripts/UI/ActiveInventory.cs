using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInventory : MonoBehaviour
{
    private int activeSlotIndexNumber = 0;
    private PlayerControls playerControls;
    private void Awake()
    {
        playerControls = new PlayerControls();
    }
    private void Start()
    {
        playerControls.Inventory.KeyBoard.performed += ctx => ToggleActiveSlot((int)ctx.ReadValue<float>());
    }
    private void OnEnable()
    {
        playerControls.Enable();

    }
    private void ToggleActiveSlot(int numValue)
    {
        ToggleActiveHightLight(numValue - 1);
    }
    private void ToggleActiveHightLight(int indexNum)
    {
        activeSlotIndexNumber = indexNum;
        foreach (Transform inventorySlot in this.transform)
        {
            inventorySlot.GetChild(0).gameObject.SetActive(false);

        }
        this.transform.GetChild(indexNum).GetChild(0).gameObject.SetActive(true);
    }


}
