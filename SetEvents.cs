using EXILED;
using EXILED.Extensions;
using Mirror;
using UnityEngine;

namespace VanHeli
{
    public class SetEvents : NetworkBehaviour
    {
        public MTFRespawn mtfRespawn;
        public ChopperAutostart mtf_a;

        public void OnRemoveAdminCommand(ref RACommandEvent ev)
        {
            switch (ev.Command)
            {
                case "heli":
                    if (this.mtf_a == null)
                    {
                        this.mtf_a = Object.FindObjectOfType<ChopperAutostart>();
                    }
                    if (this.mtf_a == null)
                    {
                        ev.Sender.RAMessage("Failed to hook ChopperAutostart, try again after round start", false);
                        return;
                    }
                    this.mtf_a.SetState(!this.mtf_a.NetworkisLanded);
                    ev.Sender.RAMessage(this.mtf_a.NetworkisLanded ? "Landing..." : "Flying away");
                    return;
                case "van":
                    if (this.mtfRespawn == null)
                    {
                        this.mtfRespawn = Object.FindObjectOfType<MTFRespawn>();
                    }
                    if (this.mtfRespawn == null)
                    {
                        ev.Sender.RAMessage("Failed to hook MTFRespawn, try again after round start", false);
                        return;
                    }
                    mtfRespawn.RpcVan();

                    ev.Sender.RAMessage("Van called");
                    return;
            }
        }

    }
}