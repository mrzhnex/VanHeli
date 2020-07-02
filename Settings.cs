using EXILED;

namespace VanHeli
{
    public class Settings : Plugin
    {
        public override string getName => "VanHeli";
        public SetEvents SetEvents;

        public override void OnEnable()
        {
            SetEvents = new SetEvents();
            Events.RemoteAdminCommandEvent += SetEvents.OnRemoveAdminCommand;
            Log.Info(getName + " on");
        }

        public override void OnDisable()
        {
            Events.RemoteAdminCommandEvent -= SetEvents.OnRemoveAdminCommand;
            Log.Info(getName + " off");
        }

        public override void OnReload() { }
    }
}