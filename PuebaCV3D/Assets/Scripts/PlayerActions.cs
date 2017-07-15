using UnityEngine;

public class PlayerActions : MonoBehaviour {

    public GameObject lanternObj;

    private Light lantern_light;
    private AudioSource aud;
    private bool isLanternActived = false;
	
	void Start () {
        this.lantern_light = this.lanternObj.GetComponent<Light>();
        this.lantern_light.enabled = this.isLanternActived;
        this.aud = this.lanternObj.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Q))
        {
            this.turnLantern();
        }
	}

    private void turnLantern()
    {
        this.isLanternActived = !this.isLanternActived;

        this.aud.Play();
        this.lantern_light.enabled = this.isLanternActived;
    }
}
