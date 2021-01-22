using UnityEngine;

public class PlayerNetwork : MonoBehaviour  {

    //Photon API: 31d933cd-12fd-4d61-8d45-3379b394905b

    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }
private void Awake()
    {
        Instance = this;
        PlayerName = "SAITA#" + Random.Range(1000, 9999);
    }
}