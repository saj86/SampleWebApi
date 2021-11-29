using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs.BasicDTO
{
    public class BasicDTO<T> where T:class
    {
        public static T GetFromjson(string json)
        {
            T obj =JsonConvert.DeserializeObject<T>(json);
            return obj;
        }

        //public static T convertToDto(Entity E)
        //{

        //    T obj =  
        //    return obj;
        //}
    }
}
