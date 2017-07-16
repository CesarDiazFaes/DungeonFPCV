using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SceneManager : MonoBehaviour {

    public GameObject playerObj;
    public GameObject playerCamera;

    private FirstPersonController fpc;
    private PlayerActions pActions;
    private CameraShake cmShake;

    // Use this for initialization
    void Start () {
        this.fpc = this.playerObj.GetComponent<FirstPersonController>();
        this.pActions = this.playerObj.GetComponent<PlayerActions>();
        this.cmShake = this.playerCamera.GetComponent<CameraShake>();
        //this.cmShake.startShake();
        this.fpc.setCanMove(false);
        this.fpc.setCanRotate(false);

        this.cmShake.wakingUpAnim();
        StartCoroutine(this.activateRotation());
    }
	
	// Update is called once per frame
	void Update () {

	}

    IEnumerator activateRotation()
    {
        yield return new WaitForSeconds(5f);
        this.pActions.setIsLoadingChain(false);
        this.fpc.setCanRotate(true);
    }
}
