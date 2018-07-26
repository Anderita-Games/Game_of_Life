using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {
	public GameObject Cell;
	public int Size = 10;
	int Border = 5;

	public RectTransform Iteration_Button;

	void Start () {
		Iteration_Button.sizeDelta = new Vector2(Screen.width, Screen.height * .2f);
		Iteration_Button.localPosition = new Vector3(0, Iteration_Button.sizeDelta.y / 2f - Screen.height / 2f);
		float Width = Screen.width / Size - 5;
		for (int a = Size; a > 0; a--) {
			for (int b = 0; b < Size; b++) {
				GameObject Clone = Instantiate(Cell);
				Clone.transform.SetParent(GameObject.Find("Canvas").transform);
				Clone.GetComponent<Cell>().Cell_Number = ((b + 1) + (a * Size) - Size);
				Clone.name = "Cell #" + Clone.GetComponent<Cell>().Cell_Number.ToString();
				Clone.GetComponent<RectTransform>().sizeDelta = new Vector2(Width, Width);
				Clone.GetComponent<RectTransform>().localPosition = new Vector3((Width + Border) * (b + .5f) - Screen.width / 2f,( Screen.height / 2f - (Width + Border) * (a - .5f)), 0);
			}
		}
	}

	public void Iteration () {
		for (int i = 1; i <= Size * Size; i++) {
			GameObject.Find("Cell #" + i).GetComponent<Cell>().Neighbor_Check();
		}
		for (int i = 1; i <= Size * Size; i++) {
			GameObject.Find("Cell #" + i).GetComponent<Cell>().Switch_State();
		}
	}
}
