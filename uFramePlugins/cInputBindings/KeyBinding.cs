using UnityEngine;

namespace uFramePlugins.cInputBindings
{
    /// <summary>
    /// A component that will process a key binding as well as provide a key binding instance to the source view.
    /// Note.  Even when adding this binding via code the component will still be added
    /// because a component is needed to process a keypress
    /// </summary>
    public class KeyBinding : ComponentCommandBinding
    {
        public string _KeyName;
        public KeyBindingEventType _KeyEventType = KeyBindingEventType.KeyDown;

        /// <summary>
        /// The binding provider.  Create the binding that the component will add to the source view here.
        /// </summary>
        /// <returns>The binding that will be added to the source view.</returns>
        protected override IBinding GetBinding()
        {
            return new ModelKeyBinding(_KeyName)
            {
                KeyEventType = _KeyEventType,
                Source = _SourceView,
                ModelMemberName = _ModelMemberName,
            };
        }

        protected virtual bool IsKey(ModelKeyBinding keyBinding)
        {
            switch (keyBinding.KeyEventType)
            {
                case KeyBindingEventType.Key:
                    return cInput.GetKey(_KeyName);

                case KeyBindingEventType.KeyUp:
                    return cInput.GetKeyUp(_KeyName);

                default:
                    return cInput.GetKeyDown(_KeyName);
            }
        }

        protected void Update()
        {
            if (Binding == null) return;

            var keyBinding = ((ModelKeyBinding)Binding);
            if (keyBinding == null) return; // Not sure how this could ever happen but nice to be safe

            if (IsKey(keyBinding))
            { CommandBinding.ExecuteCommand(); }
        }
    }
}
