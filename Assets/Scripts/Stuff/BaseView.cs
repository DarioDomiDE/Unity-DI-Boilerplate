using System;
using System.Collections.Generic;
using View = strange.extensions.mediation.impl.View;

public abstract class BaseView<T> : View where T : BaseView<T>
{
    private static List<Type> BindedList = new List<Type>();

#if UNITY_EDITOR
    /// <summary>
    /// This method assign depencies automaticly
    /// It's called once when we add component do game object and when "reset" in component-dropdown triggered
    /// </summary>
    protected virtual void Reset()
    {
        // Magic of reflection
        // For each field in your class/component we are looking only for those that are empty/null
        // .Where(field => field.GetValue(this) == null)
        foreach (var field in typeof(T).GetFields())
        {
            // Now we are looking for object (self or child) that have same name as a field
            var obj = transform.name == field.Name
                ? transform
                : CodeHelper.FindRecursive(field.Name, this.transform);

            // If we find object that have same name as field we are trying to get component that will be in type of a field and assign it
            if (obj == null)
                continue;

            if (field.FieldType.ToString() == "UnityEngine.GameObject")
            {
                field.SetValue(this, obj.gameObject);
            }
            else
            {
                field.SetValue(this, obj.GetComponent(field.FieldType));
            }
        }
    }
#endif

    protected override void Awake()
    {
        base.Awake();

        // Bind to StrangeIoC
        var mainContext = MainBootstrap.Instance.context as MainContext;

        // automaticly bind IoC of views and mediator
        var viewType = this.GetType();
        var mediatorType = Type.GetType(viewType.ToString().Replace("View", "Mediator"));
        // check if no mediator exists
        if (mediatorType == null)
            return;
        // check if mediator already binded
        if (BindedList.Contains(viewType))
            return;
        BindedList.Add(viewType);
        mainContext.mediationBinder.Bind(viewType).To(mediatorType);
    }


}
