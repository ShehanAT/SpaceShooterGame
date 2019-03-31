using UnityEngine;
using System.Collections;

public class Apple : MonoBehaviour {
	public static float     bottomY = -15f;

	void Start () {
	
	}
	

	void Update () {
		if ( transform.position.y < bottomY ) {
			Destroy( this.gameObject );
	
			ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();
		
			apScript.AppleDestroyed();                                    
		}
	}
}
