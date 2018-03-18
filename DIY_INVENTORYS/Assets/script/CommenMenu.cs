 using UnityEngine;
using UnityEngine;
using System.Collections;




public class CommenMenu : MonoBehaviour {
    private Vector2 defaulctScreens; 

    //Button config
    [System.Serializable]
    public class ButtonSetting{
        public vector2 position;
        public vector2 size;
        public GUIStyle buttonStyle;
    }

 void Start() {
    defaulctScreens.x =1920;
    defaulctScreens.y=1080;
}


void OnGUI(){

    ResizeGUImatrix();
    //when click button inventory
		if(GUI.Button(new Rect(bag.position.x,bag.position.y,bag.size.x,bag.size.y),"",bag.buttonStlye))
		{
			GUI_Menu.instance.OpenShortcutMenu("Inventory");
		}

}

//Matrix
void ResizeGUImatrix(){
    //Set Matrix
    Vector2 radio = new Vector2(Screen.width/defaulctScreens.x,Screen.height/defaulctScreens.y);
    Matrix4x4 guiMatrix = Matrix4x4.identify;
    guiMatrix.SetTRS(new Vector3(1,1,1),Quate)
}

}