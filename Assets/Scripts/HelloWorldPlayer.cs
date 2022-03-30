using Unity.Netcode;
using UnityEngine;

namespace HelloWorld
{
    public class HelloWorldPlayer : NetworkBehaviour
    {
        //public NetworkVariable<bool> UpperDrawer = new NetworkVariable<bool>(false);
        //public NetworkVariable<bool> LowerDrawer = new NetworkVariable<bool>(false);

        public NetworkVariable<Vector3> Position = new NetworkVariable<Vector3>();

        public override void OnNetworkSpawn()
        {
            if (IsOwner)
            {
                Move();
            }
            else
            {
                SpriteRenderer m_SpriteRenderer = GetComponent<SpriteRenderer>();
                m_SpriteRenderer.color = Color.blue;
            }
        }

        public void Move()
        {
            if (NetworkManager.Singleton.IsServer)
            {
                var randomPosition = GetRandomPositionOnPlane();
                transform.position = randomPosition;
                Position.Value = randomPosition;
            }
            else
            {
                SubmitPositionRequestServerRpc();
            }
        }

        [ServerRpc]
        void SubmitPositionRequestServerRpc(ServerRpcParams rpcParams = default)
        {
            Position.Value = GetRandomPositionOnPlane();
        }

        static Vector2 GetRandomPositionOnPlane()
        {
            return new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        }

        void Update()
        {
            //LowerDrawer.Value = DrawerManager.LowerDrawerClicked;
            //UpperDrawer.Value = DrawerManager.UpperDrawerClicked;

            transform.position = Position.Value;
        }
    }
}