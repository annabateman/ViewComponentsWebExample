using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace ViewComponentsWebExample.CustomComponents {
    /// <summary>
    /// Changes the display name of a model item to words if there is no override for the item.
    /// To implement, add a line to the Startup.cs
    /// ex: public string PropertyName ... becomes Property Name
    /// Found this solution on the blog post: http://www.michael-whelan.net/using-humanizer-with-asp-dotnet-core/
    /// </summary>
    public class FriendlyDisplayMetadataProvider : IDisplayMetadataProvider {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context) {
            var propertyAttributes = context.Attributes;
            var modelMetadata = context.DisplayMetadata;
            var propertyName = context.Key.Name;

            if (IsTransformRequired(propertyName, modelMetadata, propertyAttributes)) {
                modelMetadata.DisplayName = () => propertyName.CamelCaseToWords();
            }
        }

        private static bool IsTransformRequired(string propertyName, DisplayMetadata modelMetadata, IReadOnlyList<object> propertyAttributes) {
            if (!string.IsNullOrEmpty(modelMetadata.SimpleDisplayProperty))
                return false;

            if (propertyAttributes.OfType<DisplayNameAttribute>().Any())
                return false;

            if (propertyAttributes.OfType<DisplayAttribute>().Any())
                return false;

            if (string.IsNullOrEmpty(propertyName))
                return false;

            return true;
        }
    }
}
