using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour {

    [SerializeField] private GameObject cardBack;
    [SerializeField] private SceneComtroller controller;

    private int _id; 
    public int id()
    {
        return _id; 
    }

    public void SetCard(int id,Sprite image)
    {
        _id = id;
        Debug.Log(_id);
        GetComponent<SpriteRenderer>().sprite = image;
    }

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void OnMouseDown()
    {
        if (cardBack.activeSelf && controller.canReveal())
        {
            cardBack.SetActive(false);
            Debug.Log(_id);
            controller.CardRevealed(this);
           
        }
    }

    public void Unreveal()
    {
        cardBack.SetActive(true);
    }
}
