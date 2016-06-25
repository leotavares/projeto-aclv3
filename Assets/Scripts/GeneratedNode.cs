using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GeneratedNode : MonoBehaviour {
	public float info;
	public float speed = 0f;
	public NodeGenerator nodeG;

	void Update () {
		if (Input.GetKey (KeyCode.Space)&&(this.GetComponent<RectTransform> ().localPosition.x>565&&this.GetComponent<RectTransform> ().localPosition.x<715))
			 AddToTree ();

		if (speed > 0) {
			this.GetComponent<RectTransform>().position = new Vector3(this.GetComponent<RectTransform>().position.x+Time.deltaTime*speed,this.GetComponent<RectTransform>().position.y,this.GetComponent<RectTransform>().position.z);
		}
		if (this.GetComponent<RectTransform> ().localPosition.x > 1500f)
			RemoveSelf ();		
	}

	public void SetInfo(float info){
		this.info = info;
		this.GetComponentInChildren<Text> ().text = info.ToString ();
	}

	public void AddToTree(){
		GameObject.Find("Primary Node").GetComponent<BinaryTree>().InsertValue ((int)info);
		RemoveSelf ();
	}

	public void RemoveSelf(){
		//Debug.Log(nodeG.fila.RemoveFromQueue ());
		Destroy (this.gameObject);
	}
}
