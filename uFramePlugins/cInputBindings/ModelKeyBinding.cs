namespace uFramePlugins.cInputBindings
{
    /// <summary>
    /// Binds a cInput keyName to a ViewModel command.
    /// </summary>
    public class ModelKeyBinding : ModelCommandBinding
    {
        private KeyBindingEventType _keyEventType = KeyBindingEventType.KeyDown;

        public string KeyName { get; set; }

        public KeyBindingEventType KeyEventType
        {
            get { return _keyEventType; }
            set { _keyEventType = value; }
        }

        public ModelKeyBinding(string keyName)
            : base()
        {
            KeyName = keyName;
        }

        public ModelKeyBinding On(KeyBindingEventType eventType)
        {
            var keyBinding = this.Component as KeyBinding;
            if (keyBinding != null)
            {

            }
            KeyEventType = eventType;
            return this;
        }
    }
}
