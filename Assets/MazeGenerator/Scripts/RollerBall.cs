using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//<summary>
//Ball movement controlls and simple third-person-style camera
//</summary>
public class RollerBall : MonoBehaviour
{

    // public GameObject ViewCamera = null;
    public AudioClip JumpSound = null;
    public AudioClip HitSound = null;
    public AudioClip CoinSound = null;

    //comment

    public Transform ToFollow;
    public GameObject gameOverScreen = null;
    public GameObject debugCube;

    private Rigidbody mRigidBody = null;
    public AudioSource mAudioSource = null;
    private bool mFloorTouched = false;




	[SerializeField]
    private Vector3 moveDir;

	[SerializeField]
    private float speed = 1;


    void Start()
	{
    	mRigidBody = GetComponent<Rigidbody>();
        //mAudioSource = GetComponent<AudioSource>();
       // gameOverScreen.SetActive(false);
	}

    //private void Update()
    //{
    //	transform.Translate(moveDir*speed*Time.deltaTime)
    //}

    void FixedUpdate()
	{
     
        if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad))
    	{
        	Vector2 touch = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
        	Vector3 forwardDir = ToFollow.forward.normalized;
            if (touch.y > 0.5f)
        	{
                debugCube.transform.Translate(Vector3.up); //SetActive(!debugCube.activeInHierarchy);
            	transform.Translate(new Vector3(forwardDir.x, 0, forwardDir.z) * speed * Time.deltaTime, Space.World);

        	}
            else if (touch.y < -0.5f)
        	{
                debugCube.transform.Translate(Vector3.up);  // debugCube.SetActive(!debugCube.activeInHierarchy);
                transform.Translate(new Vector3(forwardDir.x, 0, forwardDir.z) * speed * -1 * Time.deltaTime, Space.World);

        	}
    	}

	}

    void OnCollisionEnter(Collision coll)
	{
        if (coll.gameObject.tag == "Floor")
    	{
        	mFloorTouched = true;
            if (mAudioSource != null && HitSound != null && coll.relativeVelocity.y > .5f)
            {
                mAudioSource.PlayOneShot(HitSound, coll.relativeVelocity.magnitude);
        	}
    	}
        else
    	{
            if (mAudioSource != null && HitSound != null && coll.relativeVelocity.magnitude > 2f)
        	{
        	    mAudioSource.PlayOneShot(HitSound, coll.relativeVelocity.magnitude);
        	}
    	}
	}

    void OnCollisionExit(Collision coll)
	{
        if (coll.gameObject.tag == "Floor")
    	{
        	mFloorTouched = false;
    	}
	}

    void OnTriggerEnter(Collider other)
		{
        if (other.gameObject.tag == "Coin") {
            if (mAudioSource != null && CoinSound != null) {
            	mAudioSource.PlayOneShot(CoinSound);
        		}
        		Destroy(other.gameObject);
    		}
        if (other.gameObject.tag == "Enemy")
    		{

            //float dt = Time.deltaTime;

            //for (int i = 0; i < dt * 10; i++)
                //gameOverScreen.SetActive(true);

            gameOverScreen.SetActive(true);

        	    
    		}
		}




}
