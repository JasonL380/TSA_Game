// Name: Jason Leech
// Date: 01/10/2023
// Desc: Script for server side networking

using Unity.Netcode;
using UnityEngine;

namespace Utils
{
    public class ServerNetwork : NetworkBehaviour
    {
        private void Start() 
        {
            NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
            NetworkManager.Singleton.StartHost();
        }

        private void ApprovalCheck(NetworkManager.ConnectionApprovalRequest request,
            NetworkManager.ConnectionApprovalResponse response)
        {
            
        }
    }
}