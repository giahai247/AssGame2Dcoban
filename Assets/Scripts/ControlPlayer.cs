using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Collections;
using System.Collections.Generic;
public class ControlPlayer : MonoBehaviour {

	//khai báo các biến
	public static bool isGameOver = false;
	public float jumpHeigh, speed;
	private Animator player;
	public bool checkdie;
	private List<GameObject> listObjs;
	private GameObject[] arrayObjs;
	int i=0;
	int score = 0;
	public Text textScore;
	// Use this for initialization
	void Start () {
		// ánh xạ ierHierachy sang code
		player = GetComponent<Animator>();

		isGameOver = false;
		//Time.deltaTime = 1;

		textScore = GameObject.Find("txtTextScore").GetComponent<Text> ();

		checkdie = false;
		listObjs = new List<GameObject> ();
		arrayObjs = GameObject.FindGameObjectsWithTag ("blood");
		foreach (GameObject obj in arrayObjs){
			listObjs.Add (obj);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.tag == "Tien") {
			
			score++;
			Destroy (coll.gameObject);
			textScore.text = "Score: " + score.ToString ();
		}
		if(coll.gameObject.tag == "Cret"){
			if(i<2){
				Destroy (listObjs [i]);
				listObjs.RemoveAt (i);
				i++;
				Debug.Log ("i=" + i.ToString ());
			}
			if(i>=2){
				
				checkdie = true;
				Application.LoadLevel ("gameover");
			}

		}
	}
	// Update is called once per frame
	void Update () {
		if (!isGameOver) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				// set trang thai cho Animator
				player.SetBool ("isRunning", true);
				player.SetBool ("isIdle", false);
				//di chuyen
				gameObject.transform.Translate (Vector3.left * speed * Time.deltaTime);
				//quay dau
				if (gameObject.transform.localScale.x > 0) {
					gameObject.transform.localScale = new Vector3 (gameObject.transform.localScale.x*-1 , gameObject.transform.localScale.y, gameObject.transform.localScale.z);
				}
			} else if (Input.GetKey (KeyCode.RightArrow)) {
				// set trang thai cho Animator
				player.SetBool ("isRunning", true);
				player.SetBool ("isIdle", false);
				//di chuyen
				gameObject.transform.Translate (Vector3.right * speed * Time.deltaTime);
				//quay dau
				if (gameObject.transform.localScale.x < 0) {
					gameObject.transform.localScale = new Vector3 (gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
				}
			} else if (Input.GetKey (KeyCode.Space)) {
				
				gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (gameObject.GetComponent<Rigidbody2D> ().velocity.x, jumpHeigh);
			}
			else{
				player.SetBool ("isRunning", false);
				player.SetBool ("isIdle", true);
			}
		
		}
	}
}
