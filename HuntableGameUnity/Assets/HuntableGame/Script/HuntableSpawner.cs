using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class HuntableSpawner : MonoBehaviour
{
    public Huntable[] prefabHuntableList;


    void Start()
    {
        if(Random.Range(0, 2) == 0){
            Huntable collectable = Instantiate(prefabHuntableList[Random.Range(0, prefabHuntableList.Length)]);
            collectable.transform.parent = transform;
            collectable.transform.localPosition = Vector3.zero;
            HuntableEvent.instance.SpawnHuntable(collectable);
        }
    }

    void OnDrawGizmos () {

        Gizmos.color = new Color (0, 1, 0, .5f);
        Gizmos.DrawSphere (transform.position, 0.5f);

        Gizmos.color = new Color (1, 1, 1, 1);
        Gizmos.DrawIcon(transform.position, "huntableGizmo.png", true);

    }
}
