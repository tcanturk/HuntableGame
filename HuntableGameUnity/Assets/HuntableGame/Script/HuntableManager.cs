using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HuntableManager : MonoBehaviour
{

    public int collectedHuntable;
    public int totalHuntable;
    public TMP_Text txtHuntableStatus;
    public Image imgHuntableStatusBar;
    public Transform playerController;
    public GazeController gazeController;
    public static HuntableManager instance;

    List<Huntable> huntableList;

    void Awake()
    {
        instance = this;
        huntableList = new List<Huntable>();
        collectedHuntable = 0;
        totalHuntable = 0;
    }

    void LateUpdate() {

        for(int i = 0; i < huntableList.Count; i++) {
            float distance = Vector3.Distance(huntableList[i].transform.position, playerController.position);
            if(distance > gazeController.gazeDistanceLimit - 0.5f /* Subtract 0.5 for sphere collider radius*/) {
                huntableList[i].OutsideRange();
            }
            else {
                huntableList[i].InsideRange();
            }
        }
    }

    public void NotifySpawnHuntable(Huntable argHuntable){
        totalHuntable++;
        UpdateStatusText();
        huntableList.Add(argHuntable);
    }

    public void CollectHuntable(Huntable argHuntable){
        collectedHuntable++;
        UpdateStatusText();
        huntableList.Remove(argHuntable);
    }

    public void FocusHuntable(Huntable argHuntable) {
        argHuntable.Focus();
    }

    public void LostFocusHuntable(Huntable argHuntable) {
        argHuntable.ResetFocus();
    }

    void UpdateStatusText(){
        txtHuntableStatus.text = collectedHuntable + " / " + totalHuntable;
        imgHuntableStatusBar.fillAmount = (float)collectedHuntable / totalHuntable;
    }

    void OnEnable()
    {
        HuntableEvent.instance.onSpawnHuntable += NotifySpawnHuntable;
        HuntableEvent.instance.onCollectHuntable += CollectHuntable;
        HuntableEvent.instance.onFocusHuntable += FocusHuntable;
        HuntableEvent.instance.onLostFocusHuntable += LostFocusHuntable;
    }

    void OnDisable() {
        HuntableEvent.instance.onSpawnHuntable -= NotifySpawnHuntable;
        HuntableEvent.instance.onCollectHuntable -= CollectHuntable;
        HuntableEvent.instance.onFocusHuntable -= FocusHuntable;
        HuntableEvent.instance.onLostFocusHuntable -= LostFocusHuntable;
    }
}
