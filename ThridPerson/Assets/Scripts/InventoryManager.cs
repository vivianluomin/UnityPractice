using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour ,GameManager{

    public ManagetStatus sstatus { get; private set; }//属性可以从任何地方获取，但只能在这个脚本中设置

    private Dictionary<string,int> items;

    public string equippedItem { get; private set; }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Startup()
    {
        items = new Dictionary<string, int>();
        sstatus = ManagetStatus.Started;
    }

    private void DisplayItems()
    {
        string itemDisplay = "Items:  ";
        foreach(KeyValuePair<string,int> item in items)
        {
            itemDisplay += item + "   ";
        }
        Debug.Log(itemDisplay);
    }

    public void AddItem(string name)
    {
        if (items.ContainsKey(name))
        {
            items[name] += 1;
        }
        else
        {
            items[name] = 1;
        }
        DisplayItems();
    }

    public List<string> GetItemList()
    {
        List<string> list = new List<string>(items.Keys);

        return list;
    }

    public int GetItemCount(string name)
    {
        if (items.ContainsKey(name))
        {
            return items[name];
        }

        return 0;
    }

    public bool EquippedItem(string name)
    {
        if(items.ContainsKey(name) && equippedItem != name)
        {
            equippedItem = name;
            return true;
        }
        equippedItem = null;
        return false;
    }

    public bool ComsumeItem(string name)
    {
        if (items.ContainsKey(name))
        {
            items[name]--;
            if(items[name] == 0)
            {
                items.Remove(name);
            }
        }
        else
        {
            return false;
        }

        DisplayItems();
        return true;
    }
}
