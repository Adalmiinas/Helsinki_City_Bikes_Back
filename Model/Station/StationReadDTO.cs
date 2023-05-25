using System;
namespace HelsinkiBikes.Model
{

    public readonly record struct StationReadDTO(int id, int stationId, string Name,
        string SwedishName, string EnglishName, string Address, string SwedishAddress,
        string City, string SwedishCityName, string Operator, int capacity, string xAxel, string yAxel);

}

