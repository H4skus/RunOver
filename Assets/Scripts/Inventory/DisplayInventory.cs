using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public MouseItem MouseItem = new MouseItem();

    public GameObject InventoryPrefab;
    public InventoryObject inventory;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BEETWEM_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BEETWEM_ITEM;
    Dictionary<GameObject, InventorySlot> itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
    // Start is called before the first frame update
    
    void Start()
    {
        CreatSlots();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSlots();
    }

    public void UpdateSlots()
    {
        foreach (KeyValuePair<GameObject, InventorySlot>_slot in itemsDisplayed)
        {
            if (_slot.Value.ID >= 0)
            {
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = inventory.database.GetItem[_slot.Value.item.Id].uiDisplay;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 1);
                _slot.Key.transform.GetComponentInChildren<TextMeshProUGUI>().text = _slot.Value.amount == 1 ? "" : _slot.Value.amount.ToString("n0");
            }
            else
            {

                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().sprite = null;
                _slot.Key.transform.GetChild(0).GetComponentInChildren<Image>().color = new Color(1, 1, 1, 0);
                _slot.Key.transform.GetComponentInChildren<TextMeshProUGUI>().text = "";
            }
        }
    }

    public void CreatSlots()
    {
        itemsDisplayed = new Dictionary<GameObject, InventorySlot>();
        for (int i = 0; i < inventory.Container.Items.Length; i++)
        {
            var obj = Instantiate(InventoryPrefab, Vector3.zero, Quaternion.identity,transform);
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);

            AddEvent(obj, EventTriggerType.PointerEnter, delegate { OnEnter(obj); });
            AddEvent(obj, EventTriggerType.PointerExit, delegate { OnExit(obj); });
            AddEvent(obj, EventTriggerType.BeginDrag, delegate { OnDragStart(obj); });
            AddEvent(obj, EventTriggerType.EndDrag, delegate { OnDragEnd(obj); });
            AddEvent(obj, EventTriggerType.Drag, delegate { OnDrag(obj); });


            itemsDisplayed.Add(obj, inventory.Container.Items[i]);
        }
    }
    private void AddEvent(GameObject obj, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        EventTrigger trigger = obj.GetComponent<EventTrigger>();
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        trigger.triggers.Add(eventTrigger);
    }

    public void OnEnter(GameObject obj)
    {
        MouseItem.hoverObj = obj;
        if (itemsDisplayed.ContainsKey(obj))
            MouseItem.hoverItem = itemsDisplayed[obj];
    }    
    public void OnExit(GameObject obj)
    {
        MouseItem.hoverObj = null;
        MouseItem.hoverItem = null;
    }    
    public void OnDrag(GameObject obj)
    {
        if (MouseItem.obj != null)
            MouseItem.obj.GetComponent<RectTransform>().position = Input.mousePosition;
    }    
    public void OnDragStart(GameObject obj)
    {
        var mouseObject = new GameObject();
        var rt = mouseObject.AddComponent<RectTransform>();
        mouseObject.transform.SetParent(transform.parent);
        if (itemsDisplayed[obj].ID >= 0)
        {
            var img = mouseObject.AddComponent<Image>();
            img.sprite = inventory.database.GetItem[itemsDisplayed[obj].ID].uiDisplay;
            img.raycastTarget = false;
        }
        MouseItem.obj = mouseObject;
        MouseItem.item = itemsDisplayed[obj];
    }    
    public void OnDragEnd(GameObject obj)
    {
        if (MouseItem.hoverObj)
        {
            inventory.MoveItem(itemsDisplayed[obj], itemsDisplayed[MouseItem.hoverObj]);
        }
        else
        {
            inventory.RemoveItem(itemsDisplayed[obj].item);
        }
        Destroy(MouseItem.obj);
        MouseItem.item = null;
    }


    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BEETWEM_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + ((-Y_SPACE_BEETWEM_ITEM)* (i/NUMBER_OF_COLUMN)),0f);
    }
}
