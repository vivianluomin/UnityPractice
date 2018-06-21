using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectileIte : MonoBehaviour {

    [SerializeField] private string itemname;

    void OnTriggerEnter(Collider other)
    {
        Managers.Inventory.AddItem(itemname);
        Destroy(this.gameObject);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
