using EXILED;
using EXILED.Extensions;
using Mirror;
using UnityEngine;

namespace VanHeli
{
    public class SetEvents : NetworkBehaviour
    {
        public MTFRespawn MTFRespawn { get; set; }
        public ChopperAutostart ChopperAutostart { get; set; }

        public void OnRemoveAdminCommand(ref RACommandEvent ev)
        {
            switch (ev.Command)
            {
                case "heli":
                    ev.Allow = false;
                    if (ChopperAutostart == null)
                    {
                        ChopperAutostart = Object.FindObjectOfType<ChopperAutostart>();
                    }
                    if (ChopperAutostart == null)
                    {
                        ev.Sender.RAMessage("Failed to hook ChopperAutostart, try again after round start", false);
                        return;
                    }
                    ChopperAutostart.SetState(!ChopperAutostart.NetworkisLanded);
                    ev.Sender.RAMessage(ChopperAutostart.NetworkisLanded ? "Landing..." : "Flying away");
                    return;
                case "van":
                    ev.Allow = false;
                    if (MTFRespawn == null)
                    {
                        MTFRespawn = FindObjectOfType<MTFRespawn>();
                    }
                    if (MTFRespawn == null)
                    {
                        ev.Sender.RAMessage("Failed to hook MTFRespawn, try again after round start", false);
                        return;
                    }
                    MTFRespawn.RpcVan();
                    ev.Sender.RAMessage("Van called");
                    return;
            }
        }
    }
}