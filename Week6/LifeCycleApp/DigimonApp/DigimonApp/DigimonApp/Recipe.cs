using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DigimonApp
{
    class Recipe
    {
        [JsonProperty("strMeal")]
        public string Name { get; set; }

        [JsonProperty("strCategory")]
        public string Category { get; set; }

        [JsonProperty("strInstructions")]
        public string Instructions { get; set; }

        [JsonProperty("strMealThumb")]
        public string Image { get; set; }

        public Recipe() { }

        public override string ToString()
        {
            return $"Name: {this.Name}, Category: {this.Category}";
        }
    }
}
