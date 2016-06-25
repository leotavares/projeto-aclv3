using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NodeGenerator : MonoBehaviour {
	public BinaryTree primaryNode;
	public int numberOfNodes;
	public GameObject prefabNode,menu;
	public RectTransform pos;

	public Queue fila = new Queue();

	private bool trigger = false;
	private int count;
	private float speed;
	private float initialTime;

	public void StartRound(int level){
		if (menu.activeSelf)
			menu.SetActive (false);
		GeneratePrimary ();
		fila.ClearQueue ();
		speed = Mathf.Log((int)Mathf.Pow((float)level,2)+1);
		initialTime = Time.time;
		count = 0;
		Debug.Log (speed);
		trigger = true;
	}

	void Update(){
		if (trigger) {
			if (count < 100 && (Time.time - initialTime) / (3/speed) > 1) {
				GameObject temp = Instantiate (prefabNode, Vector3.zero, Quaternion.identity) as GameObject;
				temp.GetComponent<RectTransform> ().SetParent (pos.transform, false);
				temp.GetComponent<RectTransform> ().localPosition = Vector3.zero;
				initialTime = Time.time;
				temp.GetComponent<GeneratedNode>().SetInfo(Random.Range ((int)0, (int)200));
				temp.GetComponent<GeneratedNode>().speed = speed;
				temp.GetComponent<GeneratedNode>().nodeG = this;
				count++;
				//fila.AddToQueue(temp.GetComponent<GeneratedNode>().info);
			} else {
				if (count >= 100)
					trigger = false;
			}
		}

		if(Input.GetKeyDown(KeyCode.Space))
			GameObject.Find("Boxxy").GetComponent<RectTransform>().localScale = new Vector3(1.2f,1.2f,1f);
		if(Input.GetKeyUp(KeyCode.Space))
			GameObject.Find("Boxxy").GetComponent<RectTransform>().localScale = new Vector3(1f,1f,1f);

	}

	public void GeneratePrimary(){
		int number = Random.Range ((int)50, (int)150);
		primaryNode.localRoot.info = number;
		primaryNode.localRoot.GetComponentInChildren<Text> ().text = number.ToString ();
	}

}
