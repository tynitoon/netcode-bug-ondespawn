using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class DummyMenu : MonoBehaviour
{
    public void HostServer()
    {
        if (NetworkManager.Singleton)
            NetworkManager.Singleton.StartHost();
    }

    public void JoinServer()
    {
        if (NetworkManager.Singleton)
            NetworkManager.Singleton.StartClient();
    }

    public void StopNetwork()
    {
        if (NetworkManager.Singleton)
            NetworkManager.Singleton.Shutdown();
    }

    public void OnExitScene() //Probably the same result than StopNetwork()
    {
        if (NetworkManager.Singleton)
        {
            NetworkManager.Singleton.Shutdown();
            Destroy(NetworkManager.Singleton.gameObject);
        }
    }
}
