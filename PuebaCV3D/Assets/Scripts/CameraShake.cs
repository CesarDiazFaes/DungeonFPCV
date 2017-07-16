using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    // How long the object should shake for.
    public float shakeDuration = 2f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.1f;
    public float decreaseFactor = 1.0f;

    Vector3 originalPos;

    public Animator anim;
    private bool isShaking = false;

    void Start()
    {
        //this.anim = this.gameObject.GetComponent<Animator>();
    }

    void OnEnable()
    {
        originalPos = this.transform.localPosition;
    }

    void Update()
    {
        if (this.isShaking)
            this.shakingEffect();
    }

    private void shakingEffect()
    {
        this.transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
    }

    public void startShake()
    {
        this.isShaking = true;
        StartCoroutine(this.stopShake());
    }

    IEnumerator stopShake()
    {
        yield return new WaitForSeconds(this.shakeDuration);
        this.isShaking = false;
        this.transform.localPosition = originalPos;
    }

    public void wakingUpAnim() {
        this.anim.Play("WakingUpHead");
    }

    public void escapeChainAnim()
    {
        this.anim.Play("EscapingChainsHead");
    }

    public void resetAnimations()
    {
        this.anim.Play("New State");
    }

    public void disableAnimator(bool b) {
        this.anim.enabled = b;
    }
}