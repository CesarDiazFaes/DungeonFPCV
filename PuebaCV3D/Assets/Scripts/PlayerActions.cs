using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerActions : MonoBehaviour {

    public SceneManager sceneMngr;

    public GameObject lanternObj;
    public GameObject ChainedObj;

    public CameraShake cmShake;

    public AudioClip chain_break_sound;

    private CharacterController ch;
    private FirstPersonController fpc;
    private Light lantern_light;
    private AudioSource lanternAud;
    private AudioSource chainsAud;

    private bool isLanternActived = false;
    private bool isLoadingChain = true;
    private bool isChained = true;
    private int chainTries = 0;
	
	void Start () {
        this.lantern_light = this.lanternObj.GetComponent<Light>();
        this.lantern_light.enabled = this.isLanternActived;
        this.lanternAud = this.lanternObj.GetComponent<AudioSource>();
        this.chainsAud = this.ChainedObj.GetComponent<AudioSource>();
        //this.ch = this.gameObject.GetComponent<CharacterController>();
        this.fpc = this.gameObject.GetComponent<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!this.isChained)
                this.turnLantern();
        }

        if (this.isChained && !this.isLoadingChain)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(this.chainsCoolDown());
                this.chainTries++;
                this.cmShake.escapeChainAnim();
                this.chainsAud.Play();

                if (this.chainTries >= 3)
                {
                    this.chainsAud.clip = this.chain_break_sound;
                    this.chainsAud.Play();
                    this.isChained = false;
                    this.fpc.setCanMove(true);
                    this.cmShake.disableAnimator(false);
                    this.ChainedObj.transform.position = new Vector3(10, 10, 10); //Can't destroy inmediatly cause we use it own audio source.
                    Destroy(this.ChainedObj, 2f);
                }
            }
        }
	}

    IEnumerator chainsCoolDown()
    {
        this.isLoadingChain = true;
        yield return new WaitForSeconds(1f);
        this.cmShake.resetAnimations();
        this.isLoadingChain = false;
    }

    private void turnLantern()
    {
        this.isLanternActived = !this.isLanternActived;

        this.lanternAud.Play();
        this.lantern_light.enabled = this.isLanternActived;
    }

    public void setIsLoadingChain(bool b)
    {
        this.isLoadingChain = b;
    }
}
