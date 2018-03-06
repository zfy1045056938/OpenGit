using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Camera))]
public class cusorAffordance : MonoBehaviour {
	[SerializeField] Texture2D WalkableCursor ;
	[SerializeField] Texture2D EnemyCursor ;
	[SerializeField] Texture2D UnknownCursor ;

	[SerializeField] Vector2 hotSpot = new Vector2(4,4);

	CameraRaycaster CameraRaycaster;
	// Use this for initialization
	void Start () {
		CameraRaycaster = GetComponent<CameraRaycaster> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (CameraRaycaster.currentLayHit) {
		case Layer.Enemy:
			Cursor.SetCursor (EnemyCursor, hotSpot, CursorMode.Auto);
			break;
		case Layer.Walkable:
			
			Cursor.SetCursor (WalkableCursor, hotSpot, CursorMode.Auto);
			break;
		case Layer.RaycastEndStop:
			Cursor.SetCursor (UnknownCursor, hotSpot, CursorMode.Auto);
			break;

		default:
			return;
		}
	}
}
