using System;
using UnityEngine;

namespace uFramePlugins.cInputBindings
{
    static class ViewBaseExtensions
    {
        /// <summary>
        /// Bind a key to a ViewModel Command
        /// </summary>
        /// <param name="t">The view that owns the binding</param>
        /// <param name="commandSelector"></param>
        /// <param name="key"></param>
        /// <param name="throttle"></param>
        /// <returns>The binding class that allows chaining extra options.</returns>
        public static ModelKeyBinding BindKey(this ViewBase t, Func<ICommand> commandSelector, string keyName, object parameter = null)
        {
            if (commandSelector == null) throw new ArgumentNullException("commandSelector");
            var kb = t.gameObject.AddComponent<KeyBinding>();
            kb._KeyName = keyName;
            kb.hideFlags = HideFlags.HideInInspector;
            var binding = kb.Binding as ModelKeyBinding;

            binding.Source = t;
            binding.CommandDelegate = commandSelector;
            binding.Component = kb;

            if (parameter != null)
            {
                binding.SetParameter(parameter);
            }

            t.AddBinding(binding);
            return binding;
        }
    }
}
