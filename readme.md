# uFrame Bindings - cInput

This is a simple plugin for uFrame to allow you to bind to cInput based events rather than the default unity input bindings, just grab the uFramePlugins folder and put it in your unity project and it should all work.

Usage looks like:

```c#
this.BindKey(() => SomeElement.SomeCommand, "TheIWinButton");
```
