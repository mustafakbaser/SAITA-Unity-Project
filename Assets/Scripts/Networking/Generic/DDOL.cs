using UnityEngine;

public class DDOL : MonoBehaviour {
    //Photon API: 31d933cd-12fd-4d61-8d45-3379b394905b
    private void Awake(){
        DontDestroyOnLoad(this);
    }
}