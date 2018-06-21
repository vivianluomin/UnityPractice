﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicUI : MonoBehaviour {

    void OnGUI()
    {
        int posX = 10;
        int posY = 10;
        int width = 100;
        int height = 230;
        int buffer = 10;

        List<string> itemList = Managers.Inventory.GetItemList();
        if(itemList.Count == 0)
        {
            GUI.Box(new Rect(posX, posY, width, height), "No Items");

        }

        foreach(string item in itemList)
        {
            int count = Managers.Inventory.GetItemCount(item);
            Texture2D image = Resources.Load<Texture2D>("icons/"
                + item);
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent("(" + count + ")", image));
            posX += width + buffer;

        }

        string equipped = Managers.Inventory.equippedItem;
        if(equipped != null)
        {
            posX = Screen.width - width - buffer;
            Texture2D image = Resources.Load<Texture2D>("icons/"
              + equipped) as Texture2D;
            GUI.Box(new Rect(posX, posY, width, height), new GUIContent("Equipped ", image));
        }
        posX = 10;
        posY += height + buffer;

        foreach(string item in itemList)
        {
            if(GUI.Button(new Rect(posX,posY,width,height),"Equip " + item))
            {
                Managers.Inventory.EquippedItem(item);
            }

            if(item == "health")
            {
                if (GUI.Button(new Rect(posX, posY, width, height), "User Health " + item))
                {
                    Managers.Inventory.ComsumeItem("health");
                    Managers.Player.ChangeHealth(25);
                }
            }
            posX += width + buffer;
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
