using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
	public int roundTime = 60;
	private float lastTimeUpdate = 0;
	private bool battleStarted = false;
	private bool battleEnded = false;

	public Text scoreLeft, scoreRight, winner, ryuWinner, kenWinner;

	public Image armor_left, ad_left, cr_left, hb_left, armor_right, ad_right, cr_right, hb_right;

	public Fighter player1;
	public Fighter player2;
	//public BannerController banner;

	private GameObject[] characterList;

	void Start(){
		//score board
		winner.enabled = false;
		ryuWinner.enabled = false;
		kenWinner.enabled = false;

		//items
		armor_left.enabled = false;
		ad_left.enabled = false;
		cr_left.enabled = false;
		hb_left.enabled = false;
		armor_right.enabled = false;
		ad_right.enabled = false;
		cr_right.enabled = false;
		hb_right.enabled = false;


		if (CharacterSelection.data == 0)
		{
			player1 = GameObject.Find("Ryu").GetComponent<Fighter>();
			//player2 = GameObject.Find("Ken_AI").GetComponent<Fighter>();
		}
		if (CharacterSelection.data == 1)
		{
			player1 = GameObject.Find("Ken").GetComponent<Fighter>();
			//player2 = GameObject.Find("Ryu_AI").GetComponent<Fighter>();
		}

		RandomItem();
	}

	private void expireTime(){

		if (player1.healthPercent > player2.healthPercent)
		{
			player2.health = 0;
		}
		else
		{
			player1.health = 0;
		}
	}

	void Update(){
		if (!battleStarted){ // !banner.isAnimating)
			battleStarted = true;

			player1.enabled = true;
			player2.enabled = true;
		}

		if (battleStarted && !battleEnded){

			if (roundTime > 0 && Time.time - lastTimeUpdate > 1){
				roundTime--;
				lastTimeUpdate = Time.time;
				if (roundTime == 0){
					expireTime();
				}
			}

			if (player1.healthPercent <= 0){
				//banner.showYouLose();
				battleEnded = true;
				scoreRight.text = "1";
				kenWinner.enabled = true;
				winner.enabled = true;
				Invoke("Ken", 5);
			}
			if (player2.healthPercent <= 0){
				//banner.showYouWin();
				battleEnded = true;
				scoreLeft.text = "1";
				ryuWinner.enabled = true;
				winner.enabled = true;
				Invoke("Ryu", 5);
			}

			//Move

				if (Input.GetKey(KeyCode.W) || player1.healthPercent > 0.1)
				{
					transform.Translate(0f, 0f, 0.1f);
				}
				if (Input.GetKey(KeyCode.S) || player1.healthPercent > 0.1)
				{
					transform.Translate(0f, 0f, -0.1f);
				}
				if (Input.GetKey(KeyCode.D) || player1.healthPercent > 0.1)
				{
					transform.Translate(0.1f, 0f, 0f);
				}
				if (Input.GetKey(KeyCode.A) || player1.healthPercent > 0.1)
				{
					transform.Translate(-0.1f, 0f, 0f);
			}
		}
	}

	public void RandomItem()
	{
		switch (Random.Range(1, 5))
		{
			case 1:
				armor_left.enabled = true;
				player1.health = 110;
				break;
			case 2:
				ad_left.enabled = true;
				//HitCollider.setDamage(20);
				break;
			case 3:
				cr_left.enabled = true;
				//HitCollider.setDamage(20);
				break;
			case 4:
				hb_left.enabled = true;
				player1.health = 120;
				break;
			default:
				armor_left.enabled = true;
				break;
		}
		switch (Random.Range(1, 5))
		{
			case 1:
				armor_right.enabled = true;
				player2.health = 110;
				break;
			case 2:
				ad_right.enabled = true;
				//HitCollider.setDamage(20);
				break;
			case 3:
				cr_right.enabled = true;
				//HitCollider.setDamage(20);
				break;
			case 4:
				hb_right.enabled = true;
				player2.health = 120;
				break;
			default:
				armor_right.enabled = true;
				break;
		}
	}

	public void Ken() {
		SceneManager.LoadScene("Main");
	}
	public void Ryu(){
		SceneManager.LoadScene("Main");
	}
}