using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour {
	public bool Alive = false;
	public int Cell_Number;
	int Neighbors_Alive = 0;

	public void Pressed () {
		if (Alive == false) {
			Alive = true;
		}else {
			Alive = false;
		}
	}

	void Update () {
		if (Alive == false) {
			this.GetComponent<UnityEngine.UI.RawImage>().color = Color.black;
		}else {
			this.GetComponent<UnityEngine.UI.RawImage>().color = Color.white;
		}
	}

	public void Neighbor_Check () {
		int Size = GameObject.Find("Canvas").GetComponent<GameMaster>().Size;
		Neighbors_Alive = 0;

		for (int a = 1; a > -2; a--) { //Neighbor Check
			for (int b = -1; b < 2; b++) {
				int Cell_Number_Temp = Cell_Number + (a * Size) + b;
				if (Cell_Number_Temp != Cell_Number && GameObject.Find("Cell #" + Cell_Number_Temp)) {
					if (GameObject.Find("Cell #" + Cell_Number_Temp).GetComponent<Cell>().Alive == true) {
						if (Cell_Number % Size == 0 && (Cell_Number + 1 == Cell_Number_Temp || Cell_Number + 1 + Size == Cell_Number_Temp || Cell_Number + 1 - Size == Cell_Number_Temp)) { //Right side overlap cancel
						}else if ((Cell_Number - 1) % Size == 0 && (Cell_Number - 1 == Cell_Number_Temp || Cell_Number - 1 + Size == Cell_Number_Temp || Cell_Number - 1 - Size == Cell_Number_Temp)) { //Left side overlap cancel
						}else {
							Neighbors_Alive++;
						}
					}
				}
			}
		}
	}

	public void Switch_State () {
		if (Alive == true) {
			if (Neighbors_Alive > 3 || Neighbors_Alive < 2) {
				Alive = false;
			}
		}else if (Alive == false && Neighbors_Alive == 3) {
			Alive = true;
		}
	}
}
