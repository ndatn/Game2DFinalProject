using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActiveInventory : Singleton<ActiveInventory>
{
    private int activeSlotIndexNum = 0;

    private PlayerControls playerControls;

    protected override void Awake()
    {
        base.Awake();

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

    public void EquipStartingWeapon()
    {
        ToggleActiveHighlight(0);
    }

    private void ToggleActiveSlot(int numValue)
    {
        ToggleActiveHighlight(numValue - 1);
    }

    private void ToggleActiveHighlight(int indexNum)
    {
        if (this == null)
        {
            return;
        }

        activeSlotIndexNum = indexNum;

        foreach (Transform inventorySlot in this.transform)
        {
            if (inventorySlot != null)
            {
                inventorySlot.GetChild(0)?.gameObject.SetActive(false);
            }
        }

        Transform activeSlot = this.transform.GetChild(indexNum);
        if (activeSlot != null)
        {
            activeSlot.GetChild(0)?.gameObject.SetActive(true);
        }

        ChangeActiveWeapon();
    }

    private void ChangeActiveWeapon()
    {

        if (ActiveWeapon.Instance.CurrentActiveWeapon != null)
        {
            Destroy(ActiveWeapon.Instance.CurrentActiveWeapon.gameObject);
        }

        Transform childTransform = transform.GetChild(activeSlotIndexNum);
        if (childTransform != null)
        {
            InventorySlot inventorySlot = childTransform.GetComponentInChildren<InventorySlot>();
            if (inventorySlot != null)
            {
                WeaponInfo weaponInfo = inventorySlot.GetWeaponInfo();
                if (weaponInfo != null)
                {
                    GameObject weaponToSpawn = weaponInfo.weaponPrefab;
                    GameObject newWeapon = Instantiate(weaponToSpawn, ActiveWeapon.Instance.transform);
                    ActiveWeapon.Instance.NewWeapon(newWeapon.GetComponent<MonoBehaviour>());
                    return;
                }
            }
        }

        ActiveWeapon.Instance.WeaponNull();
    }
}
