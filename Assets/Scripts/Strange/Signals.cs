using strange.extensions.signal.impl;

public class StartSignal : Signal { }

// Signals Mediator to Controller

public class TryBlaSignal : Signal<string> { }
public class TryBlubbSignal : Signal<string> { }

// Signals Controller to Mediator

public class DoBlaSignal : Signal { }
public class DoBlubbSignal : Signal { }

