using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class PropertyCopier<TParent, TChild> where TParent : class where TChild : class
{
    /// <summary>
    /// PropertyCopier<SourceClassName, TargetClassName>.Copy_SourceToTarget(SourceObject, TargetObject);
    /// </summary>
    /// <param name="parent"></param>
    /// <param name="child"></param>
    public static void Copy_SourceToTarget(TParent parent, TChild child)
    {
        var parentProperties = parent.GetType().GetProperties();
        var childProperties = child.GetType().GetProperties();
        foreach (var parentProperty in parentProperties)
        {
            foreach (var childProperty in childProperties)
            {
                if (parentProperty.Name == childProperty.Name && parentProperty.PropertyType == childProperty.PropertyType)
                {
                    childProperty.SetValue(child, parentProperty.GetValue(parent)); break;
                }
            }
        }

        //How to use
        //PropertyCopier<SourceClassName, TargetClassName>.Copy_SourceToTarget(SourceObject, TargetObject);
    }
}