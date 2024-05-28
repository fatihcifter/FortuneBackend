using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;

namespace FortuneTellerApi.Utility
{
    public class CustomObjectMapper
    {
        public TDestination Map<TSource, TDestination>(TSource sourceObject)
        {
            try{ 
            var destinationObject = Activator.CreateInstance<TDestination>();
            if (sourceObject != null)
            {
                foreach (var sourceProperty in typeof(TSource).GetProperties())
                {
                    var destinationProperty =
                    typeof(TDestination).GetProperty
                    (sourceProperty.Name);
                    if (destinationProperty != null)
                    {
                        destinationProperty.SetValue
                        (destinationObject,
                       sourceProperty.GetValue(sourceObject));
                    }
                }
            }
            return destinationObject;
            }
            catch (Exception ex) {
               return  Activator.CreateInstance<TDestination>();
            }
            }
    }
}
