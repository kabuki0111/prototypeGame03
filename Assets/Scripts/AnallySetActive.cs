using UnityEngine;
using System.Collections;

public class AnallySetActive : MonoBehaviour {
	private const int DATAS_MAX = 12;
	
	public float valueActive = 0;
	private int datesMax = DATAS_MAX;	
	public GameObject[] anallyDatas = new GameObject[DATAS_MAX];
	public float activeTime = 9.0f;
	
	// Update is called once per frame
	void Update ()
	{		
		valueActiveTimer();
	}
	
	void valueActiveTimer()
	{
		valueActive += Time.deltaTime;
		
		if( valueActive >= activeTime )
		{
			int point = Random.Range(0, datesMax);
			
			anallyDatas[point].SetActive(true);
			
			valueActive = 0;
			
		}		
	}
	
}
