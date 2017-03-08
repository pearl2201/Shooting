using UnityEngine;
using System.Collections;

public class TestAnim : MonoBehaviour {

    public string nameAnim;
    public Animation anim;
	// Use this for initialization
	void Start () {
        Debug.Log("count anim: " + anim.GetClipCount());
        AnimationClip clip = anim.GetClip(nameAnim);
        anim.clip = clip;
        anim.Play();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
