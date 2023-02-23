using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType 
    {
    Mixed, //0
    Shepherd, //1
    Hound, //2
    Terrier, //3
    Retriever, //4
    Pointer, //5
    Mastiff //6
    }
    public enum PetColorType 
    {
    White, //0
    Black, //1
    Yellow, //2
    Spotted, //3
    Tricolor, //4
    Red, //5
    Brindle //6
    }
    public class Pet 
    {
    public int id {get; set;}
    
    [Required]
    public string name {get; set;}
    
    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetBreedType breed {get; set;}

    [Required]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public PetColorType color {get; set;}

    public string checkedInAt {get; set;} 

    [ForeignKey("petOwner")]
    public int petOwnerId {get; set;}

    public PetOwner petOwner {get; set;}
}
}
