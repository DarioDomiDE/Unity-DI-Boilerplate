using strange.extensions.signal.impl;

public class StartSignal : Signal { }

// Signals Mediator to Controller

public class TryLoginSignal : Signal { }

// Signals Controller to Mediator

public class LoggedInSignal : Signal<string> { }
public class LoginFailedSignal : Signal { }

