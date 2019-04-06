using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(AudioManager))]

public class Managers : MonoBehaviour
{
    public static PlayerManager Player { get; private set; }
    public static AudioManager Audio { get; private set; }
    
    private List<IGameManager> _startSequence;

    private void Awake()
    {
        Player = GetComponent<PlayerManager>();
        

        _startSequence = new List<IGameManager>();
        _startSequence.Add(Player);
        

        StartCoroutine(StartupManagers());
    }

    private IEnumerator StartupManagers()
    {
        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup();
        }
        yield return null;

        int numModules = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModules)
        {
            int lastReady = numReady;
            numReady = 0;

            foreach(IGameManager manager in _startSequence)
            {
                if(manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
            if (numReady > lastReady)
                Debug.Log(" ");
            yield return null;
        }
        Debug.Log(" ");
    }

}
