using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeController : MonoBehaviour
{
    public float gazeDistanceLimit;

    RaycastHit hit;

    Huntable preHC;

    public static GazeController instance;
    

    void Awake()
    {
        instance = this;
        preHC = null;
    }

    void FixedUpdate() {
        
        if (Physics.Raycast(transform.position, transform.forward, out hit, gazeDistanceLimit))
        {
            if (hit.transform.tag == "Huntable")
            {
                Huntable hc = hit.transform.gameObject.GetComponent<Huntable>();
                if(preHC != null && hc != preHC){
                    HuntableEvent.instance.LostFocusHuntable(preHC);
                }
                preHC = hc;
                HuntableEvent.instance.FocusHuntable(hc);

            }
            else {
                if(preHC != null){
                    HuntableEvent.instance.LostFocusHuntable(preHC);
                }
            }
        }
        else {
            if(preHC != null){
                HuntableEvent.instance.LostFocusHuntable(preHC);
            }
        }
        
    }
}
