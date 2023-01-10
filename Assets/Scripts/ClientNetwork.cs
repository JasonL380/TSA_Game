// Name: Jason Leech
// Date: 01/10/2023
// Desc:

using Unity.Netcode;
using UnityEngine;

namespace Utils
{
    public class ClientNetwork : NetworkBehaviour
    {
        private void Start() 
        {
            NetworkManager.Singleton.ConnectionApprovalCallback = ApprovalCheck;
            NetworkManager.Singleton.StartClient();
        }

        private void ApprovalCheck(NetworkManager.ConnectionApprovalRequest request,
            NetworkManager.ConnectionApprovalResponse response)
        {
            
        }
    }
}