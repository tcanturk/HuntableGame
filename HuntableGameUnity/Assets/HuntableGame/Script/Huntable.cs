using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Huntable : MonoBehaviour
{

    public float fillSpeed;
    public Transform transformCanvas;
    public Transform huntParticle;
    public Image imgPassiveRing;
    public Image imgActiveRing;
    public Image imgFocusRing;

    HuntableSM huntableSM;

    // Start is called before the first frame update
    void Start()
    {
        huntableSM = new HuntableSM();
        huntableSM.onChangeState += onChangeHuntableState;
        huntableSM.Init();
        huntableSM.SetFillSpeed(fillSpeed);
    }

    void Update() {
        transformCanvas.LookAt(Camera.main.transform.position);    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        huntableSM.Update();
        imgFocusRing.fillAmount = huntableSM.value;
    }

    private void onChangeHuntableState(string stateName){

        Debug.Log(stateName);
        
        if(stateName == "passive") {
            imgPassiveRing.gameObject.SetActive(true);
            imgActiveRing.gameObject.SetActive(false);
        }
        else if(stateName == "idle") {
            imgPassiveRing.gameObject.SetActive(false);
            imgActiveRing.gameObject.SetActive(true);
        }
        else if(stateName == "hunt") {
            GetHuntable();
        }
    }

    public void Focus() {
        huntableSM.Focus();
    }

    public void ResetFocus() {
        huntableSM.Reset();
    }

    public void InsideRange() {
        huntableSM.Active();
    }

    public void OutsideRange() {
        huntableSM.Passive();
    }

    public void GetHuntable(){
        huntableSM.onChangeState -= onChangeHuntableState;
        HuntableEvent.instance.CollectHuntable(this);
        Transform particle = Instantiate(huntParticle);
        particle.position = transform.position;
        Destroy(gameObject);
    }
}
