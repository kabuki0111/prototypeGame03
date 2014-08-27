using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float		shotspeed		= 200.0f;
	public float 		pftlong			= 100.0f;
	public GameObject	masterObj;
	
	public void Update ()
	{
		BulletShot();
	}
	
	private void BulletShot()
	{
		GameObject playerTag = masterObj;
		
		Vector3 tamaspd = new Vector3( 0, 0, shotspeed );
		transform.Translate( tamaspd * Time.deltaTime );
		
		//destroy long
		if (Vector3.Distance( playerTag.transform.position, transform.position ) >= pftlong)
		{
			Destroy(gameObject);
		}
	}
	

}