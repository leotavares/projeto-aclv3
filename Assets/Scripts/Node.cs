using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Node : MonoBehaviour {
	public Node left,right,father;
	public int bal;
	public float info;
	public RectTransform brn;
	public Text infoTxt;

	public Node(){}

	public Node(float info){
		SetInfo (info);
	}

	public void SetInfo(float i){
		this.info = i;
		infoTxt.text = i.ToString ();
	}

	public void SetBal(int b, int height){
		bal = b;
		float angle = -15f * bal/height;
		transform.GetComponent<RectTransform>().localRotation = Quaternion.Euler (0, 0, angle);

		Vector3 localPos = GetComponent<RectTransform>().localPosition;

		float h = Mathf.Sqrt(localPos.x*localPos.x+localPos.y*localPos.y);
		if (brn != null) {
			this.brn.sizeDelta = new Vector2 (70, h);
			float error = -Mathf.Rad2Deg * Mathf.Atan (localPos.x / localPos.y);

			if((angle>=0&&error<0)||(angle<0&&error>0)||(angle>=0&&error>0)||(angle<0&&error<0))
				error-=angle;

			this.brn.localRotation = Quaternion.Euler (0, 0,  error);
		}
	}
}
