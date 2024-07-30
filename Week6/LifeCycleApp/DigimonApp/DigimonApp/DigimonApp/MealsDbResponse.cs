using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DigimonApp
{
    class MealsDbResponse
    {
        [JsonProperty("meals")]
        public List<Recipe> RecipeList { get; set;}

        public MealsDbResponse() { }
    }
}
