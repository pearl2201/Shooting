using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {
	public float destroyTime;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
//		Color c = transform.GetChild(0).GetComponent<Renderer>().material.GetColor("_Color");
//		c.a -= Time.deltaTime / destroyTime;
//		transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", c);
	}

	public void setDestroy(float time)
	{
		destroyTime = time;

		Invoke("t",destroyTime);
	}

	void t()
	{
        PoolManager.ReleaseObject(gameObject);
	}
}
