using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntableEvent : MonoBehaviour
{

    public static HuntableEvent instance;

    public event Action<Huntable> onSpawnHuntable;
    public event Action<Huntable> onCollectHuntable;

    public event Action<Huntable> onFocusHuntable;
    public event Action<Huntable> onLostFocusHuntable;

    
    void Awake()
    {
        instance = this;
    }

    public void SpawnHuntable(Huntable argHuntable){
        if(onSpawnHuntable != null){
            onSpawnHuntable(argHuntable);
        }
    }

    public void CollectHuntable(Huntable argHuntable){
        if(onCollectHuntable != null) {
            onCollectHuntable(argHuntable);
        }
    }

    public void FocusHuntable(Huntable argHuntable){
        if(onFocusHuntable != null){
            onFocusHuntable(argHuntable);
        }
    }

    public void LostFocusHuntable(Huntable argHuntable){
        if(onLostFocusHuntable != null) {
            onLostFocusHuntable(argHuntable);
        }
    }
}
