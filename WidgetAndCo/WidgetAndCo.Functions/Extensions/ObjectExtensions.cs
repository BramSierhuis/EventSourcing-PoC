namespace WidgetAndCo.Functions.Extensions;

public static class ObjectExtensions
{
    public static object GetUpdatedObject(this object originalObj, object updatedObj)
    {
        foreach (var property in updatedObj.GetType().GetProperties())
        {
            if (property.GetValue(updatedObj, null) == null)
            {
                property.SetValue(updatedObj,originalObj.GetType().GetProperty(property.Name)
                    ?.GetValue(originalObj, null));
            }
        }
        return updatedObj;
    }
}