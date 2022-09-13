using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeAPI.Models
{
    public class Sprites
    {
        public int Id { get; set; }
        [JsonProperty("front_default")]
        public string? FrontDefault { get; set; } = string.Empty;
        [JsonProperty("front_shiny")]
        public string? FrontShiny { get; set; } = string.Empty;
        [JsonProperty("other")]
        public Other? Other { get; set; }
    }

    public class Type
    {
        public int Id { get; set; }
        [JsonProperty("slot")]
        public int Slot { get; set; }
        [JsonProperty("type")]
        public TypeName? TypeName { get; set; }
    }

    public class TypeName
    {
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;
    }

    public class OfficialArtwork
    {
        public int Id { get; set; }

        [JsonProperty("front_default")]
        public string? FrontDefault { get; set; } = string.Empty;
    }

    public class Other
    {
        public int Id { get; set; }
        [JsonProperty("official-artwork")]
        public OfficialArtwork? OfficialArtwork { get; set; }
    }

    public class Pokemon
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;
        [JsonProperty("sprites")]
        public Sprites? Sprites { get; set; }
        [JsonProperty("types")]
        public List<Type>? Types { get; set; }

        public override string ToString()
        {
            return Id + ": " + Name[..1].ToUpper() + Name[1..];
        }
    }
}
