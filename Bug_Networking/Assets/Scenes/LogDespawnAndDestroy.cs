using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class LogDespawnAndDestroy : NetworkBehaviour
{
    private string m_PlayerIdentifier = "(Unknown)";

    public override void OnNetworkSpawn()
    {
        if (NetworkObject.IsPlayerObject)
        {
            if (IsServer)
            {
                m_PlayerIdentifier = $"[Server-Side] Player-{OwnerClientId}";
            }
            else
            {
                m_PlayerIdentifier = $"[Client-Side] Player-{OwnerClientId}";
            }
        }
        base.OnNetworkSpawn();
    }

    public override void OnNetworkDespawn()
    {
        Debug.Log($"{m_PlayerIdentifier} NetworkObject despawned!");
        base.OnNetworkDespawn();
    }

    public override void OnDestroy()
    {
        Debug.Log($"{m_PlayerIdentifier} NetworkObject destroyed!");
        base.OnDestroy();
    }
}
