using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BinaryTree : MonoBehaviour {
	public Node localRoot;
	public GameObject prefabNode;
	public GameObject gameOver;

	public void InsertValue(int x){
		bool b = false;
		bool c = false;
		int a = 0;
		InsertNode (ref localRoot, null, x, a,ref b,ref c);
	}
	
	public void InsertNode(ref Node root,Node father, int x, int height, ref bool ok, ref bool changedHeight){
		if (root == null) {//achou o lugar de x
			GameObject aux = Instantiate(prefabNode) as GameObject;
			aux.transform.SetParent(father.GetComponent<RectTransform>(),false);
			aux.transform.SetAsFirstSibling();

			float localX;
			if(father!=null)
				localX = father.info > x? (float)-210f/(height):(float)210f/(height);
			else
				localX =(float) 0;

			Vector3 localPos =  new Vector3(localX,105f,0); 

			aux.GetComponent<RectTransform>().localPosition = localPos;
	
			aux.GetComponent<Node>().SetInfo(x);
			aux.GetComponent<Node>().SetBal(0,height);
			aux.GetComponent<Node>().left=null;
			aux.GetComponent<Node>().right=null;

			root = aux.GetComponent<Node>();
			ok=true;
			changedHeight=true;
		}else{
			if(x==root.info){//r.info igual a x
				Debug.Log("Ja tem um numero");
				ok = false;
				changedHeight = false;
			}else{
				height++;
				if(root.info>x){//x menor que root.info
					InsertNode(ref root.left,root,x, height, ref ok,ref changedHeight);

					if(changedHeight){
						switch(root.bal){
							case 1:
								root.SetBal(0,height);
								changedHeight = false;
								break;
							case 0:
								root.SetBal(-1,height);
								break;
							case -1:
								root.SetBal(-2,height);
								TreeBreak(root);
								break;
						}
					}
				}else{//x maior que root.info
					InsertNode(ref root.right,root,x,height,ref ok,ref changedHeight);

					if(changedHeight){
						switch(root.bal){
						case -1:
							root.SetBal(0,height);
							changedHeight = false;
							break;
						case 0:
							root.SetBal(1,height);
							break;
						case 1:
							root.SetBal(2,height);
							TreeBreak(root);
							break;
						}
					}
				}
			}
		}
	}

	public void TreeBreak(Node r){
		//r.GetComponent<RectTransform> ().localRotation = Quaternion.Euler (0, 0, 180);
		Debug.Log ("PERDEU");
		Time.timeScale = 0.0f;
		gameOver.SetActive (true);
	}
}
