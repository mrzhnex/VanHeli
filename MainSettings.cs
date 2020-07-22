using EXILED;

namespace VanHeli
{
    public class MainSettings : Plugin
    {
        public override string getName => nameof(VanHeli);
        public SetEvents SetEvents { get; set; }

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