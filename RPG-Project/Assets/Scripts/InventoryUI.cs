using UnityEngine;

public class InventoryUI : MonoBehaviour {
	
	Inventory inventory;

	public Transform itemsParent;


	// Use this for initialization
	void Start () {
		inventory = Inventory.instance;
		inventory.OnItemChangedCallback += UpdateUI;

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void UpdateUI ()
	{
        InventorySlot[] slots = itemsParent.GetComponentsInChildren<InventorySlot>();
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count) {
				slots[i].AddItem(inventory.items[i]);
			} else 
			{
				slots[i].ClearSlot ();

			}
		}
	}
		
}
