using RestSharp;
using System.Collections.Generic;
using System.Reflection;
using SampleFunctionAppNew.Types;

namespace SampleFunctionAppNew.Helper
{
    public static class RestSharpHelper
    {
        public static void AddParameter<T>(T model, RestRequest request)
        {
            foreach (var propertyInfo in model.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string))
                {
                    var fieldId = propertyInfo.GetCustomAttributesData().GetFieldId();

                    if (fieldId == null)
                    {
                        continue;
                    }

                    var value = (string)propertyInfo.GetValue(model);

                    request.AddParameter(fieldId, value);
                }
                else if (propertyInfo.PropertyType == typeof(AddressType))
                {
                    var fieldId = propertyInfo.GetCustomAttributesData().GetFieldId();
                    var address = (AddressType)propertyInfo.GetValue(model);

                    if (fieldId == null || address == default(AddressType))
                    {
                        continue;
                    }

                    request.AddParameter($"{fieldId}[address]", address.Address);
                    request.AddParameter($"{fieldId}[address2]", address.Address2);
                    request.AddParameter($"{fieldId}[city]", address.City);
                    request.AddParameter($"{fieldId}[state]", address.State);
                    request.AddParameter($"{fieldId}[country]", address.Country);
                    request.AddParameter($"{fieldId}[zip]", address.Zip);
                    request.AddParameter($"{fieldId}[lng]", address.Longitute);
                    request.AddParameter($"{fieldId}[lat]", address.Latitude);
                }
                else if (propertyInfo.PropertyType == typeof(NameType))
                {
                    var fieldId = propertyInfo.GetCustomAttributesData().GetFieldId();
                    var name = (NameType)propertyInfo.GetValue(model);

                    if (fieldId == null || name == default(NameType))
                    {
                        continue;
                    }

                    request.AddParameter($"{fieldId}[title]", name.Title);
                    request.AddParameter($"{fieldId}[first_name]", name.FirstName);
                    request.AddParameter($"{fieldId}[middle_name]", name.MiddleName);
                    request.AddParameter($"{fieldId}[last_name]", name.LastName);
                }
                else if (propertyInfo.PropertyType == typeof(LinkType))
                {
                    var fieldId = propertyInfo.GetCustomAttributesData().GetFieldId();
                    var link = (LinkType)propertyInfo.GetValue(model);

                    if (fieldId == null || link == default(LinkType))
                    {
                        continue;
                    }

                    request.AddParameter($"{fieldId}[link]", link.Link);
                }
                else if (propertyInfo.PropertyType == typeof(CalendarType))
                {
                    var fieldId = propertyInfo.GetCustomAttributesData().GetFieldId();
                    var calendar = (CalendarType)propertyInfo.GetValue(model);

                    if (fieldId == null || calendar == default(CalendarType))
                    {
                        continue;
                    }

                    request.AddParameter($"{fieldId}[start]", calendar.Start.ToString("yyyy-MM-dd HH:mm:ss"));
                    request.AddParameter($"{fieldId}[end]", calendar.End.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else if (propertyInfo.PropertyType == typeof(TimeType))
                {
                    var fieldId = propertyInfo.GetCustomAttributesData().GetFieldId();
                    var time = (string)(TimeType)propertyInfo.GetValue(model);

                    if (fieldId == null || time == null)
                    {
                        continue;
                    }

                    request.AddParameter(fieldId, $"'{time}'");
                }
                else if (propertyInfo.PropertyType == typeof(Dictionary<string, string>))
                {
                    var fieldId = propertyInfo.GetCustomAttributesData().GetFieldId();
                    var dictionary = (Dictionary<string, string>)propertyInfo.GetValue(model);

                    if (fieldId == null || dictionary == null)
                    {
                        continue;
                    }

                    foreach (var key in dictionary.Keys)
                    {
                        request.AddParameter($"{fieldId}[{key}]", dictionary[key]);
                    }
                }
                else if (propertyInfo.PropertyType == typeof(MultiType))
                {
                    var fieldId = propertyInfo.GetCustomAttributesData().GetFieldId();
                    var multiType = (Dictionary<string, string>)(MultiType)propertyInfo.GetValue(model);

                    if (fieldId == null || multiType == null)
                    {
                        continue;
                    }

                    //If there is one record, we just need to send it with the fieldId
                    if (multiType.Count == 1)
                    {
                        request.AddParameter($"{fieldId}", multiType["0"]);
                    }
                    else
                    {
                        foreach (var key in multiType.Keys)
                        {
                            request.AddParameter($"{fieldId}[{key}]", multiType[key]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get JsonProperty data from attribute
        /// </summary>
        /// <param name="customAttributeDatas"></param>
        /// <returns></returns>
        private static string GetFieldId(this IList<CustomAttributeData> customAttributeDatas)
        {

            if (customAttributeDatas.Count == 0 || customAttributeDatas[0].ConstructorArguments.Count == 0)
            {
                return null;
            }

            return customAttributeDatas[0].ConstructorArguments[0].Value.ToString();
        }
    }
}

