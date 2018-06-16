using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SceneComtroller : MonoBehaviour {

    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Sprite[] images;
    [SerializeField] private TextMesh scoreLabel;

    public const int gridRows = 2;
    public const int gridCols = 4;
    public const float offsetX = 2;
    public const float offsetY = 2.5f;

    private MemoryCard _firstRevealed;
    private MemoryCard _secondRevealed;

    private int _score = 0;


	// Use this for initialization
	void Start () {
        Vector3 startPos = originalCard.transform.position;
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };
        numbers = ShuffleArray(numbers);

        for(int i = 0; i < gridCols; i++)
        {
            for(int j = 0; j < gridRows; j++)
            {
                MemoryCard card;
                if(i == 0&& j == 0)
                {
                    card = originalCard;

                }
                else
                {
                    card = Instantiate(originalCard) as MemoryCard;
                }

                int index = j * gridCols + i;
                int id = numbers[index];
                card.SetCard(id, images[id]);

                float posX = (offsetX * i) + startPos.x;
                float posY = - (offsetY * j) + startPos.y;
                card.transform.position = new  Vector3(posX, posY, startPos.z);
            }
        }
    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private int[] ShuffleArray(int[] numbers)
    {
        // int[] newArray = numbers.Clone() as int[];
        Debug.Log(numbers.Length);
        for(int i = 0; i < numbers.Length; i++)
        {
            int temp = numbers[i];
            int r = UnityEngine.Random.Range(i, numbers.Length);
            numbers[i] = numbers[r];
            numbers[r] = temp;
         //   Debug.Log(temp);


        }
        return numbers;
    }

    public bool canReveal()
    {
        return _secondRevealed == null;
    }

    public void CardRevealed(MemoryCard card)
    {

        Debug.Log(card.id());
        if (_firstRevealed == null)
        {
            _firstRevealed = card;    
        }
        else
        {
            _secondRevealed = card;
            StartCoroutine(CheckMatch());
        }
    }

    private IEnumerator CheckMatch()
    {
        if(_firstRevealed.id() == _secondRevealed.id())
        {
            _score++;
           
            scoreLabel.text = "Score: " + _score;

        }
        else
        {
            yield return new WaitForSeconds(.5f);
            _firstRevealed.Unreveal();
            _secondRevealed.Unreveal();
                 
        }

        _firstRevealed = null;
        _secondRevealed = null;
    }

    public void Restart()
    {
        Application.LoadLevel("Card");
    }
}
