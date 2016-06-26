using UnityEngine;
using System.Collections;

public class Queue{
	QueueNode first;

	public Queue(){}

	public bool AddToQueue(float info){
		QueueNode aux = first;
		while (aux!=null||first==null) {
			aux = aux.anterior;
		}

		aux = new QueueNode ();
		aux.info = info;
		aux.anterior = null;

		return true;
	}

	public bool AddToQueue(QueueNode node){
		QueueNode aux = first;
		while (aux!=null) {
			aux = aux.anterior;
		}
		
		aux = node;
		aux.anterior = null;
		
		return true;
	}

	public float RemoveFromQueue(){
		float i;
		i = first.info;
		first = first.anterior;

		return i;
	}

	public void ClearQueue(){
		GameObject[] nodes = GameObject.FindGameObjectsWithTag("Node");
		int number = nodes.Length;

		for(int i = 0; i < number; i++){
			Object.Destroy(nodes[i]);
		}

		GameObject[] generatedNodes = GameObject.FindGameObjectsWithTag("Generated Node");
		int n = generatedNodes.Length;
		
		for(int i = 0; i < n; i++){
			Object.Destroy(generatedNodes[i]);
		}

	}
}
