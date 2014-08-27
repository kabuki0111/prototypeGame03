using UnityEngine;
using System.Collections;

public class EnemySetActive : MonoBehaviour {
	//setting objects data
			const int DATAS_MAX = 12;
		
	public	GameObject[]	enemyDatas	= new GameObject[DATAS_MAX];
	public	float			activeTime	= 2.0f;
	
			float			startTimer	= 0;
			int				datesMax	= DATAS_MAX;
	
	// Update is called once per frame
	void Update ()
	{
		startTimer += Time.deltaTime;
		
		if( startTimer >= activeTime )
		{
			//timer re-turn
			startTimer = EnemysDataActive( startTimer );
		}
	
	}
	
	
	//enemy go to the player spot.
	float EnemysDataActive( float timer )
	{
		
		if( GuiDate.scorePoint <= (int)Enemy.enemyLevel.level1 )
		{
			int point		= Random.Range(0, datesMax);
			enemyDatas[ point ].SetActive(true);
		}
		else if( (GuiDate.scorePoint > (int)Enemy.enemyLevel.level1) && (GuiDate.scorePoint <= (int)Enemy.enemyLevel.level2) )
		{
			int point		= Random.Range(0, datesMax);
			int sub_point	= Random.Range(0, datesMax);
			enemyDatas[ point ].SetActive(true);
			enemyDatas[ sub_point ].SetActive(true);
		}
		else if( (GuiDate.scorePoint > (int)Enemy.enemyLevel.level2) && (GuiDate.scorePoint <= (int)Enemy.enemyLevel.level3) )
		{
			int point		= Random.Range(0, datesMax);
			int sub_point	= Random.Range(0, datesMax);
			enemyDatas[point].SetActive(true);	
		}
		else if( (GuiDate.scorePoint > (int)Enemy.enemyLevel.level3) && (GuiDate.scorePoint <= (int)Enemy.enemyLevel.level4) )
		{
			int point		= Random.Range(0, datesMax);
			int sub_point	= Random.Range(0, datesMax);
			enemyDatas[point].SetActive(true);
		}
		else if( (GuiDate.scorePoint > (int)Enemy.enemyLevel.level4) && (GuiDate.scorePoint <= (int)Enemy.enemyLevel.level5) )
		{
			int point		= Random.Range(0, datesMax);
			int sub_point	= Random.Range(0, datesMax);
			enemyDatas[point].SetActive(true);
		}
		else if( (GuiDate.scorePoint > (int)Enemy.enemyLevel.level5) && (GuiDate.scorePoint <= (int)Enemy.enemyLevel.level_MAX) )
		{
			int point		= Random.Range(0, datesMax);
			int sub_point	= Random.Range(0, datesMax);
			enemyDatas[point].SetActive(true);
		}
		
		
		return 0;
	}
	
	//void EnemySetFunc
	
}