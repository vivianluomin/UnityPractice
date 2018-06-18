using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [SerializeField] private Text scoreLabel;
    [SerializeField] private SettingsPopup settingsPopup;

    private int score;

    void Awake()
    {
        Messenger.AddListener(GameEvent.ENEMY_HIT, onEnemyHit);
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, onEnemyHit);
    }
	// Use this for initialization
	void Start () {
        score = 0;
        scoreLabel.text = score.ToString();
        settingsPopup.Close();
	}
	
	// Update is called once per frame
	void Update () {
       // scoreLabel.text = Time.realtimeSinceStartup.ToString();
	}

    public void OnOpenSetting()
    {
        settingsPopup.Open();
    }

    private void onEnemyHit()
    {
        score++;
        scoreLabel.text = score.ToString();
    }
}
