using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent (typeof(InventoryManager))]
public class Managers : MonoBehaviour {

    public static PlayerManager Player
    {
        get;private set;
    }

    public static InventoryManager Inventory
    {
        get;
        private set;
    }

    private List<GameManager> startSequence;

    void Awake()
    {
        Player = GetComponent<PlayerManager>();
        Inventory = GetComponent<InventoryManager>();

        startSequence = new List<GameManager>();
        startSequence.Add(Player);
        startSequence.Add(Inventory);

        StartCoroutine(StartupManagers());

    }

    private IEnumerator StartupManagers()
    {
        foreach(GameManager manager in startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int numModules = startSequence.Count;
        int numReady = 0;
        while (numReady < numModules)
        {
            int lastReaedy = numReady;
            numReady = 0;
            foreach(GameManager  manager in startSequence)
            {
                if(manager.sstatus == ManagetStatus.Started)
                {
                    numReady++;
                }
            }

            if(numReady > lastReaedy)
            {
                yield return null;
            }
        }
      
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
