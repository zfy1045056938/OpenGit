using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{


	[SerializeField] float WalkAndStopRadius= 0.2f;

    ThirdPersonCharacter m_Character;   // A reference to the ThirdPersonCharacter on the object
	//RayHit
    CameraRaycaster cameraRaycaster;
	//Target Point 
    Vector3 currentClickTarget;
        

	//TODO
	bool isDirectMode= false;


    private void Start()
    {
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        m_Character = GetComponent<ThirdPersonCharacter>();
        currentClickTarget = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
		
		if (Input.GetKeyDown(KeyCode.G) ){
			print ("Press G");
			isDirectMode =!isDirectMode;
			currentClickTarget = transform.position;
		}

			if (isDirectMode) {
			ProcessdirectMovement();
			}else{
			ProcesseMouseMovement();
			}
       
	}

			/// <summary>
			/// DirectlyMovement
			/// </summary>
	private void ProcessdirectMovement(){
				// read inputs
				float h = Input.GetAxis("Horizontal");
				float v = Input.GetAxis("Vertical");
			


					// calculate camera relative direction to move:
				Vector3	cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
		Vector3 movement = v * cameraForward + h * Camera.main.transform.right;
		// pass all parameters to the character control script
		m_Character.Move(movement, false, false);
	}



			/// <summary>
			/// MouseMovement
			/// </summary>
	private void  ProcesseMouseMovement(){
		if (Input.GetMouseButton(0))
		{
			

			switch (cameraRaycaster.currentLayHit) {

			case Layer.Walkable:
				currentClickTarget = cameraRaycaster.hit.point;
				m_Character.Move (currentClickTarget, false, false);
				//m_Character.Move (currentClickTarget, false,false);
				break;
//			case Layer.Enemy:
//				print ("Emeny");
//				break;
//			case Layer.RaycastEndStop:
//				print ("none");
//				break;

			default:
				print ("None happen");
				break;
					
			}
			m_Character.Move (currentClickTarget, false, false);

		}


		//
		var PlayerToClickPoint =currentClickTarget-transform.position;
		if (PlayerToClickPoint.magnitude >= WalkAndStopRadius) {
			m_Character.Move (PlayerToClickPoint, false, false);
		} else {
			m_Character.Move (Vector3.zero, false, false);
		}
	}
}

